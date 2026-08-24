CREATE DATABASE pds_app_web;
USE pds_app_web;

CREATE TABLE processos (
	id_pro INT NOT NULL AUTO_INCREMENT,
    numero_pro VARCHAR(200) NOT NULL, 
    data_pro DATE NOT NULL,
    interessado_pro VARCHAR(200) NOT NULL, 
    assunto_pro VARCHAR(300) NOT NULL,
    descricao_pro TEXT NULL,
    situacao_pro VARCHAR(50) NOT NULL DEFAULT "Aberto",
    
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    
    PRIMARY KEY(id_pro)
);


INSERT INTO processos
    (numero_pro, data_pro, interessado_pro, assunto_pro, descricao_pro, situacao_pro)
VALUES
    ('PROC-2026-001', '2026-01-10', 'Joao da Silva', 'Solicitacao de licenca', 'Pedido de licenca para funcionamento comercial.', 'Aberto'),
    ('PROC-2026-002', '2026-01-18', 'Maria Oliveira', 'Regularizacao cadastral', 'Atualizacao dos dados cadastrais da interessada.', 'Em analise'),
    ('PROC-2026-003', '2026-02-03', 'Empresa Alfa Ltda.', 'Renovacao de alvara', 'Solicitacao de renovacao do alvara de funcionamento.', 'Concluido'),
    ('PROC-2026-004', '2026-02-15', 'Carlos Pereira', 'Recurso administrativo', 'Recurso referente a decisao administrativa anterior.', 'Pendente'),
    ('PROC-2026-005', '2026-03-01', 'Associacao Comunitaria Esperanca', 'Solicitacao de apoio', 'Pedido de apoio para realizacao de evento comunitario.', 'Aberto'),
    ('PROC-2026-006', '2026-03-12', 'Ana Souza', 'Emissao de certidao', 'Solicitacao de emissao de certidao negativa.', 'Concluido'),
    ('PROC-2026-007', '2026-04-05', 'Construtora Horizonte S.A.', 'Aprovacao de projeto', 'Analise e aprovacao de projeto de construcao civil.', 'Em analise'),
    ('PROC-2026-008', '2026-04-20', 'Pedro Almeida', 'Denuncia administrativa', 'Registro de denuncia sobre irregularidade em estabelecimento.', 'Aberto'),
    ('PROC-2026-009', '2026-05-08', 'Instituto Novo Futuro', 'Convenio institucional', NULL, 'Pendente'),
    ('PROC-2026-010', '2026-05-25', 'Comercio Central Ltda.', 'Baixa de inscricao', 'Solicitacao de encerramento e baixa da inscricao municipal.', 'Arquivado');


/*
INSERT INTO processos 
(numero_pro, interessado_pro, assunto_pro, descricao_pro, situacao_pro)
VALUES
('2026/000001', 'João da Silva', 'Solicitação de documentação', 'Solicitação para análise e regularização de documentação.', 'Aberto'),
('2026/000002', 'Maria Oliveira', 'Pedido de licença', 'Pedido de licença para funcionamento de estabelecimento comercial.', 'Em análise'),
('2026/000003', 'Carlos Santos', 'Requerimento administrativo', 'Requerimento referente à atualização de cadastro junto ao órgão responsável.', 'Aberto'),
('2026/000004', 'Ana Pereira', 'Solicitação de atendimento', 'Solicitação de atendimento para esclarecimento de pendências administrativas.', 'Concluído'),
('2026/000005', 'Empresa XYZ Ltda.', 'Regularização cadastral', 'Processo destinado à regularização de informações cadastrais da empresa.', 'Em análise'),
('2026/000006', 'Pedro Almeida', 'Pedido de revisão', 'Solicitação de revisão de decisão administrativa anteriormente registrada.', 'Aberto'),
('2026/000007', 'Fernanda Costa', 'Solicitação de certidão', 'Pedido de emissão de certidão para fins administrativos.', 'Concluído'),
('2026/000008', 'Comércio ABC Ltda.', 'Pedido de autorização', 'Solicitação de autorização para realização de atividade comercial.', 'Pendente'),
('2026/000009', 'Ricardo Martins', 'Atualização de cadastro', 'Solicitação de atualização dos dados cadastrais do interessado.', 'Em análise'),
('2026/000010', 'Juliana Ferreira', 'Recurso administrativo', 'Apresentação de recurso contra decisão emitida em processo anterior.', 'Aberto');
*/




