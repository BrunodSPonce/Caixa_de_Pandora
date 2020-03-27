export interface Servidor {
    servidorID: Int32Array;
    ip: string;
    hostname: string;
    observacao: string;
    status: boolean;
    tipoServidor: string;
    espacoDisco: Int16Array;
    cpu: Int16Array;
    memoria: Int16Array;
    conteudo: string;
    ambienteID: Int32Array;
    nomeAmbiente: string;
    responsabilidadeID: Int32Array;
    nomeResponsabilidade: string;
    datacenterID: Int32Array;
    nomeDataCenter: string;
    sistemaOperacionalID: Int32Array;
    nomeSistemaOperacional: string;
    distribuicao: string;
    versao: string;
    categoriaBackupID: Int32Array;
    nomeCategoriaBackup: string;
    descricao: string;
    finalidadeID: Int32Array;
    nomeFinalidade: string;
}