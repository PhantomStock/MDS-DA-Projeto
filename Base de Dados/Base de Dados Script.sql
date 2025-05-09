use basededadosda;

CREATE TABLE Utilizador (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    Tipo ENUM('Gestor', 'Programador') NOT NULL
);

CREATE TABLE Gestor (
    Id INT PRIMARY KEY,
    Departamento ENUM('IT', 'Marketing', 'Administração') NOT NULL,
    GereUtilizadores BOOLEAN DEFAULT FALSE,
    FOREIGN KEY (Id) REFERENCES Utilizador(Id)
);

CREATE TABLE Programador (
    Id INT PRIMARY KEY,
    NivelExperiencia ENUM('Júnior', 'Sénior') NOT NULL,
    IdGestor INT NOT NULL,
    FOREIGN KEY (Id) REFERENCES Utilizador(Id),
    FOREIGN KEY (IdGestor) REFERENCES Gestor(Id)
);

CREATE TABLE TipoTarefa (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL
);

CREATE TABLE Tarefa (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Descricao TEXT NOT NULL,
    OrdemExecucao INT NOT NULL,
    DataPrevistaInicio DATE NOT NULL,
    DataPrevistaFim DATE NOT NULL,
    DataRealInicio DATE,
    DataRealFim DATE,
    DataCriacao DATETIME DEFAULT CURRENT_TIMESTAMP,
    EstadoAtual ENUM('ToDo', 'Doing', 'Done') DEFAULT 'ToDo',
    -- Não sabia quantos eram então botei de 1 a 10 
    StoryPoints INT CHECK (StoryPoints BETWEEN 1 AND 10),
    IdTipoTarefa INT NOT NULL,
    IdGestor INT NOT NULL,
    IdProgramador INT NOT NULL,
    -- DeepSeek ajudou 
    FOREIGN KEY (IdTipoTarefa) REFERENCES TipoTarefa(Id),
    FOREIGN KEY (IdGestor) REFERENCES Gestor(Id),
    FOREIGN KEY (IdProgramador) REFERENCES Programador(Id),
    UNIQUE (IdProgramador, OrdemExecucao),
    -- Check serve pra a data de inicio nunca ser menor que a de fim
    CHECK (DataPrevistaFim >= DataPrevistaInicio)
);
/*=======================================================================================================================*/
-- View para tarefas Doing por programador
CREATE VIEW v_TarefasDoingPorProgramador AS
SELECT 
	IdProgramador, COUNT(*) AS TarefasDoing
FROM Tarefa
WHERE EstadoAtual = 'Doing'
GROUP BY IdProgramador;
/*=======================================================================================================================*/
-- View para relatório de tempo de execução
CREATE VIEW v_RelatorioTempoTarefas AS
SELECT 
    t.Id,
    p.Nome 		AS Programador,
    t.Descricao,
    t.DataPrevistaInicio,
    t.DataPrevistaFim,
    tt.Nome 	AS TipoTarefa,
    t.DataRealInicio,
    t.DataRealFim,
    DATEDIFF(t.DataRealFim, t.DataRealInicio) AS DiasExecucao,
    DATEDIFF(t.DataRealFim, t.DataRealInicio) - DATEDIFF(t.DataPrevistaFim, t.DataPrevistaInicio) AS DiferencaDias
FROM Tarefa t
JOIN Programador p ON t.IdProgramador = p.Id
JOIN TipoTarefa tt ON t.IdTipoTarefa = tt.Id
WHERE t.EstadoAtual = 'Done';