using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioServidorController : ControllerBase
    {
        List<Servidor> servidores = new List<Servidor>();
        List<DataCenter> datacenters = new List<DataCenter>();
        List<SistemaOperacional> sistemas = new List<SistemaOperacional>();
        List<Finalidade> finalidades = new List<Finalidade>();
        List<Responsabilidade> responsabilidades = new List<Responsabilidade>();
        List<Ambiente> ambientes = new List<Ambiente>();
        List<CategoriaBackup> backups = new List<CategoriaBackup>();
        Servidor servidor = new Servidor();

        [HttpGet]
        [Route("{id}")]
        public Servidor HttpPegarPorId(int id)
        {
            //var connectionString = "Server=172.20.1.50;Database=SistemaInventarioDev;User Id=uniteste;Password=devteste;";
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (System.InvalidOperationException e)
                {
                    throw new Exception("Algo de errado aconteceu entre em contato com o administrador", e);
                }
                using (SqlCommand command = new SqlCommand("SELECT s.ServidorID, s.IP, s.Hostname, s.Observacao, s.Status, s.TipoServidor, s.EspacoDisco, s.Cpu, " +
                    "s.Memoria, s.Conteudo, dc.NomeDataCenter, f.NomeFinalidade, so.NomeSistemaOperacional, so.Versao, so.Distribuicao, r.NomeResponsabilidade, " +
                    "cb.NomeCategoriaBackup, cb.Descricao, a.NomeAmbiente " +
                    "FROM Servidor AS s INNER JOIN DataCenter as dc ON s.dataCenterID = dc.dataCenterID " +
                    "INNER JOIN Finalidade AS f ON s.finalidadeID = f.finalidadeID " +
                    "INNER JOIN SistemaOperacional AS so ON s.sistemaOperacionalID = so.sistemaOperacionalID " +
                    "INNER JOIN Responsabilidade AS r ON s.responsabilidadeID = r.responsabilidadeID " +
                    "INNER JOIN CategoriaBackup AS cb ON s.categoriabackupID = cb.categoriabackupID " +
                    "INNER JOIN Ambiente AS a ON s.ambienteID = a.ambienteID WHERE servidorId = @Id", connection))
                {
                    command.Parameters.Add(new SqlParameter("Id", id));

                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())

                        {
                            int servidorID = reader.GetInt32(0);
                            string ip = reader.GetString(1);
                            string hostname = reader.GetString(2);
                            string observacao = reader.GetString(3);
                            bool status = reader.GetBoolean(4);
                            string tipoServidor = reader.GetString(5);
                            int espacoDisco = reader.GetInt16(6);
                            int cpu = reader.GetInt16(7);
                            int memoria = reader.GetInt16(8);
                            string conteudo = reader.GetString(9);
                            string nomeDataCenter = reader.GetString(10);
                            string nomeFinalidade = reader.GetString(11);
                            string nomeSistemaOperacional = reader.GetString(12);
                            string distribuicao = reader.GetString(13);
                            string versao = reader.GetString(14);
                            string nomeResponsabilidade = reader.GetString(15);
                            string nomeCategoriaBackup = reader.GetString(16);
                            string descricao = reader.GetString(17);
                            string nomeAmbiente = reader.GetString(18);


                            servidor = (new Servidor()
                            {
                                ServidorID = servidorID,
                                IP = ip,
                                Hostname = hostname,
                                Observacao = observacao,
                                Status = status,
                                TipoServidor = tipoServidor,
                                EspacoDisco = espacoDisco,
                                Cpu = cpu,
                                Memoria = memoria,
                                Conteudo = conteudo,
                                NomeDataCenter = nomeDataCenter,
                                NomeFinalidade = nomeFinalidade,
                                NomeSistemaOperacional = nomeSistemaOperacional,
                                Distribuicao = distribuicao,
                                Versao = versao,
                                NomeResponsabilidade = nomeResponsabilidade,
                                NomeCategoriaBackup = nomeCategoriaBackup,
                                Descricao = descricao,
                                NomeAmbiente = nomeAmbiente
                            });
                        }
                        if (servidor.IP != null)
                        {
                            connection.Close();
                            return servidor;
                        }
                        else
                        {
                            throw new Exception("Servidor não encontrado, entre em contato com o administrador");
                        }
                    }
                }
            }
        }

        [HttpGet]
        public List<Servidor> HttpPegarTodosServidores()
        {
            //var connectionString = "Server=172.20.1.50;Database=SistemaInventarioDev;User Id=uniteste;Password=devteste;";
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT s.ServidorID, s.IP, s.Hostname, s.Observacao, s.Status, s.TipoServidor, s.EspacoDisco, s.Cpu, " +
                    "s.Memoria, s.Conteudo, dc.NomeDataCenter, f.NomeFinalidade, so.NomeSistemaOperacional, so.Versao, so.Distribuicao, r.NomeResponsabilidade, " +
                    "cb.NomeCategoriaBackup, cb.Descricao, a.NomeAmbiente " +
                    "FROM Servidor AS s INNER JOIN DataCenter as dc ON s.dataCenterID = dc.dataCenterID " +
                    "INNER JOIN Finalidade AS f ON s.finalidadeID = f.finalidadeID " +
                    "INNER JOIN SistemaOperacional AS so ON s.sistemaOperacionalID = so.sistemaOperacionalID " +
                    "INNER JOIN Responsabilidade AS r ON s.responsabilidadeID = r.responsabilidadeID " +
                    "INNER JOIN CategoriaBackup AS cb ON s.categoriabackupID = cb.categoriabackupID " +
                    "INNER JOIN Ambiente AS a ON s.ambienteID = a.ambienteID", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int servidorID = reader.GetInt32(0);
                        string ip = reader.GetString(1);
                        string hostname = reader.GetString(2);
                        string observacao = reader.GetString(3);
                        bool status = reader.GetBoolean(4);
                        string tipoServidor = reader.GetString(5);
                        int espacoDisco = reader.GetInt16(6);
                        int cpu = reader.GetInt16(7);
                        int memoria = reader.GetInt16(8);
                        string conteudo = reader.GetString(9);
                        string nomeDataCenter = reader.GetString(10);
                        string nomeFinalidade = reader.GetString(11);
                        string nomeSistemaOperacional = reader.GetString(12);
                        string distribuicao = reader.GetString(13);
                        string versao = reader.GetString(14);
                        string nomeResponsabilidade = reader.GetString(15);
                        string nomeCategoriaBackup = reader.GetString(16);
                        string descricao = reader.GetString(17);
                        string nomeAmbiente = reader.GetString(18);


                        servidores.Add(new Servidor()
                        {
                            ServidorID = servidorID,
                            IP = ip,
                            Hostname = hostname,
                            Observacao = observacao,
                            Status = status,
                            TipoServidor = tipoServidor,
                            EspacoDisco = espacoDisco,
                            Cpu = cpu,
                            Memoria = memoria,
                            Conteudo = conteudo,
                            NomeDataCenter = nomeDataCenter,
                            NomeFinalidade = nomeFinalidade,
                            NomeSistemaOperacional = nomeSistemaOperacional,
                            Distribuicao = distribuicao,
                            Versao = versao,
                            NomeResponsabilidade = nomeResponsabilidade,
                            NomeCategoriaBackup = nomeCategoriaBackup,
                            Descricao = descricao,
                            NomeAmbiente = nomeAmbiente
                        });
                    }
                    if (servidores.Count > 0)
                    {
                        connection.Close();
                        return servidores;
                    }
                    else
                    {
                        connection.Close();
                        throw new Exception("Nenhum servidor encontrado, entre em contato com o administrador");
                    }
                }
            }
        }
        [HttpPost]
        public void HttpSalvarServidor(Servidor servidor)
        {
            //var connectionString = "Server=172.20.1.50;Database=SistemaInventarioDev;User Id=uniteste;Password=devteste;";
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Servidor VALUES(@ip, @hostname, @observacao, @status, " +
                    "@tipoServidor, @espacoDisco, @cpu, @memoria, @conteudo, @ambienteID, @categoriaBackupID, @datacenterID, @finalidadeID, @responsabilidadeID," +
                    " @sistemaOperacionalID)", connection))
                {
                   
                    command.Parameters.Add(new SqlParameter("ip", servidor.IP));
                    command.Parameters.Add(new SqlParameter("hostname", servidor.Hostname));
                    command.Parameters.Add(new SqlParameter("observacao", servidor.Observacao));
                    command.Parameters.Add(new SqlParameter("status", servidor.Status));
                    command.Parameters.Add(new SqlParameter("tipoServidor", servidor.TipoServidor));
                    command.Parameters.Add(new SqlParameter("espacoDisco", servidor.EspacoDisco));
                    command.Parameters.Add(new SqlParameter("cpu", servidor.Cpu));
                    command.Parameters.Add(new SqlParameter("memoria", servidor.Memoria));
                    command.Parameters.Add(new SqlParameter("conteudo", servidor.Conteudo));
                    command.Parameters.Add(new SqlParameter("ambienteID", HttpPegarIDAmbiente(servidor.NomeAmbiente)));
                    command.Parameters.Add(new SqlParameter("categoriaBackupID", HttpPegarIDBackup(servidor.NomeCategoriaBackup, servidor.Descricao)));
                    command.Parameters.Add(new SqlParameter("datacenterID", HttpPegarIDDataCenter(servidor.NomeDataCenter)));
                    command.Parameters.Add(new SqlParameter("finalidadeID", HttpPegarIDFinalidade(servidor.NomeFinalidade)));
                    command.Parameters.Add(new SqlParameter("responsabilidadeID", HttpPegarIDResponsabildiade(servidor.NomeResponsabilidade)));
                    command.Parameters.Add(new SqlParameter("sistemaOperacionalID", HttpPegarIDSistemaOperacional(servidor.NomeSistemaOperacional, servidor.Versao,
                        servidor.Distribuicao)));
                    command.ExecuteNonQuery();

                }
            }
        }

        [HttpPut("{id}")]
        public void HttpAlterarServidor(Servidor servidor)
        {
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE Servidor SET ip = @ip, hostname = @hostname, observacao = @observacao, status = @status, " +
                    "tipoServidor = @tipoServidor, espacoDisco = @espacoDisco, cpu = @cpu, memoria = @memoria, conteudo = @conteudo," +
                    " ambienteID = @ambienteID, categoriaBackupID = @categoriaBackupID, datacenterID = @datacenterID,  finalidadeID = @finalidadeID," +
                    " responsabilidadeID = @responsabilidadeID, sistemaOperacionalID = @sistemaOperacionalID WHERE servidorID = @id", connection))
                {
                    if (VerificaPorID(servidor.ServidorID))
                    {
                        command.Parameters.Add(new SqlParameter("id", servidor.ServidorID));
                        command.Parameters.Add(new SqlParameter("ip", servidor.IP));
                        command.Parameters.Add(new SqlParameter("hostname", servidor.Hostname));
                        command.Parameters.Add(new SqlParameter("observacao", servidor.Observacao));
                        command.Parameters.Add(new SqlParameter("status", servidor.Status));
                        command.Parameters.Add(new SqlParameter("tipoServidor", servidor.TipoServidor));
                        command.Parameters.Add(new SqlParameter("espacoDisco", servidor.EspacoDisco));
                        command.Parameters.Add(new SqlParameter("cpu", servidor.Cpu));
                        command.Parameters.Add(new SqlParameter("memoria", servidor.Memoria));
                        command.Parameters.Add(new SqlParameter("conteudo", servidor.Conteudo));
                        command.Parameters.Add(new SqlParameter("ambienteID", servidor.AmbienteID));
                        command.Parameters.Add(new SqlParameter("categoriaBackupID", servidor.CategoriaBackupID));
                        command.Parameters.Add(new SqlParameter("datacenterID", servidor.DatacenterID));
                        command.Parameters.Add(new SqlParameter("finalidadeID", servidor.FinalidadeID));
                        command.Parameters.Add(new SqlParameter("responsabilidadeID", servidor.ResponsabilidadeID));
                        command.Parameters.Add(new SqlParameter("sistemaOperacionalID", servidor.SistemaOperacionalID));
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        throw new Exception("Não foi possível encontrar o servidor");
                    }
                }
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public void HttpApagarServidor(int id)
        {
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Servidor WHERE servidorId = @Id", connection))
                {
                    if (VerificaPorID(id))
                    {
                        command.Parameters.Add(new SqlParameter("Id", id));
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        throw new Exception("Não foi possível encontrar o servidor");
                    }
                }
            }
        }
        [HttpGet]
        [Route("datacenter")]
        public List<DataCenter> HttpPegarTodosDataCenter()
        {
            //var connectionString = "Server=172.20.1.50;Database=SistemaInventarioDev;User Id=uniteste;Password=devteste;";
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM DataCenter", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int datacenterID = reader.GetInt32(0);
                        string nomeDataCenter = reader.GetString(1);


                        datacenters.Add(new DataCenter() { DataCenterID = datacenterID, NomeDataCenter = nomeDataCenter });
                    }
                    if (datacenters.Count > 0)
                    {
                        connection.Close();
                        return datacenters;
                    }
                    else
                    {
                        connection.Close();
                        throw new Exception("Nenhum datacenter encontrado, entre em contato com o administrador");
                    }
                }
            }
        }
        [HttpGet]
        [Route("sistemaoperacional")]
        public List<SistemaOperacional> HttpPegarTodosSistemaOperacional()
        {
            //var connectionString = "Server=172.20.1.50;Database=SistemaInventarioDev;User Id=uniteste;Password=devteste;";
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM SistemaOperacional", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int sistemaOperacionalID = reader.GetInt32(0);
                        string nomeSistemaOperacional = reader.GetString(1);
                        string distribuicao = reader.GetString(2);
                        string versao = reader.GetString(3);

                        sistemas.Add(new SistemaOperacional()
                        { SistemaOperacionalID = sistemaOperacionalID, NomeSistemaOperacional = nomeSistemaOperacional, Distribuicao = distribuicao, Versao = versao });
                    }
                    if (sistemas.Count > 0)
                    {
                        connection.Close();
                        return sistemas;
                    }
                    else
                    {
                        connection.Close();
                        throw new Exception("Nenhum sistema operacional encontrado, entre em contato com o administrador");
                    }
                }
            }
        }
        [HttpGet]
        [Route("backup")]
        public List<CategoriaBackup> HttpPegarTodosBackup()
        {
            //var connectionString = "Server=172.20.1.50;Database=SistemaInventarioDev;User Id=uniteste;Password=devteste;";
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM CategoriaBackup", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int categoriaBackupID = reader.GetInt32(0);
                        string nomeCategoriaBackup = reader.GetString(1);
                        string descricao = reader.GetString(2);

                        backups.Add(new CategoriaBackup()
                        { CategoriaBackupID = categoriaBackupID, NomeCategoriaBackup = nomeCategoriaBackup, Descricao = descricao });
                    }
                    if (backups.Count > 0)
                    {
                        connection.Close();
                        return backups;
                    }
                    else
                    {
                        connection.Close();
                        throw new Exception("Nenhum backup encontrado, entre em contato com o administrador");
                    }
                }
            }
        }
        [HttpGet]
        [Route("responsabilidade")]
        public List<Responsabilidade> HttpPegarTodasResponsabilidades()
        {
            //var connectionString = "Server=172.20.1.50;Database=SistemaInventarioDev;User Id=uniteste;Password=devteste;";
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Responsabilidade", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int responsabildadeID = reader.GetInt32(0);
                        string nomeResponsabilidade = reader.GetString(1);

                        responsabilidades.Add(new Responsabilidade()
                        { ResponsabilidadeID = responsabildadeID, NomeResponsabildiade = nomeResponsabilidade });
                    }
                    if (responsabilidades.Count > 0)
                    {
                        connection.Close();
                        return responsabilidades;
                    }
                    else
                    {
                        connection.Close();
                        throw new Exception("Nenhum responsável encontrado, entre em contato com o administrador");
                    }
                }
            }
        }
        [HttpGet]
        [Route("finalidade")]
        public List<Finalidade> HttpPegarTodasFinalidades()
        {
            //var connectionString = "Server=172.20.1.50;Database=SistemaInventarioDev;User Id=uniteste;Password=devteste;";
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Finalidade", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int finalidadeID = reader.GetInt32(0);
                        string nomeFinalidade = reader.GetString(1);

                        finalidades.Add(new Finalidade()
                        { FinalidadeID = finalidadeID, NomeFinalidade = nomeFinalidade });
                    }
                    if (finalidades.Count > 0)
                    {
                        connection.Close();
                        return finalidades;
                    }
                    else
                    {
                        connection.Close();
                        throw new Exception("Nenhuma finalidade encontrada, entre em contato com o administrador");
                    }
                }
            }
        }
        [HttpGet]
        [Route("ambiente")]
        public List<Ambiente> HttpPegarTodosAmbientes()
        {
            //var connectionString = "Server=172.20.1.50;Database=SistemaInventarioDev;User Id=uniteste;Password=devteste;";
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Ambiente", connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int ambienteID = reader.GetInt32(0);
                        string nomeAmbiente = reader.GetString(1);

                        ambientes.Add(new Ambiente()
                        { AmbienteID = ambienteID, NomeAmbiente = nomeAmbiente });
                    }
                    if (ambientes.Count > 0)
                    {
                        connection.Close();
                        return ambientes;
                    }
                    else
                    {
                        connection.Close();
                        throw new Exception("Nenhum ambiente encontrado, entre em contato com o administrador");
                    }
                }
            }
        }
        public int HttpPegarIDAmbiente(string nomeAmbiente)
        {
            //var connectionString = "Server=172.20.1.50;Database=SistemaInventarioDev;User Id=uniteste;Password=devteste;";
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Ambiente WHERE NomeAmbiente = @nomeAmbiente", connection))
                {
                    command.Parameters.Add(new SqlParameter("nomeAmbiente", nomeAmbiente));

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int ambienteID = reader.GetInt32(0);
                        if (ambienteID > 0)
                        {
                            connection.Close();
                            return ambienteID;
                        }
                        else
                        {
                            connection.Close();
                            throw new Exception("Nenhum ambiente encontrado, entre em contato com o administrador");
                        }
                    }
                    return 0;
                }
            }
        }
        public int HttpPegarIDFinalidade(string nomeFinalidade)
        {
            //var connectionString = "Server=172.20.1.50;Database=SistemaInventarioDev;User Id=uniteste;Password=devteste;";
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Finalidade WHERE NomeFinalidade = @nomeFinalidade", connection))
                {
                    command.Parameters.Add(new SqlParameter("nomeFinalidade", nomeFinalidade));

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int finalidadeID = reader.GetInt32(0);
                        if (finalidadeID > 0)
                        {
                            connection.Close();
                            return finalidadeID;
                        }
                        else
                        {
                            connection.Close();
                            throw new Exception("Nenhuma finalidade encontrado, entre em contato com o administrador");
                        }
                    }
                    return 0;
                }
            }
        }
        public int HttpPegarIDResponsabildiade(string nomeResponsabildiade)
        {
            //var connectionString = "Server=172.20.1.50;Database=SistemaInventarioDev;User Id=uniteste;Password=devteste;";
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Responsabilidade WHERE NomeResponsabildiade = @nomeResponsabildiade", connection))
                {
                    command.Parameters.Add(new SqlParameter("nomeResponsabildiade", nomeResponsabildiade));

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int responsabilidadeID = reader.GetInt32(0);
                        if (responsabilidadeID > 0)
                        {
                            connection.Close();
                            return responsabilidadeID;
                        }
                        else
                        {
                            connection.Close();
                            throw new Exception("Nenhum ambiente encontrado, entre em contato com o administrador");
                        }
                    }
                    return 0;
                }
            }
        }
        public int HttpPegarIDDataCenter(string nomeDataCenter)
        {
            //var connectionString = "Server=172.20.1.50;Database=SistemaInventarioDev;User Id=uniteste;Password=devteste;";
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM DataCenter WHERE NomeDataCenter = @nomeDataCenter", connection))
                {
                    command.Parameters.Add(new SqlParameter("nomeDataCenter", nomeDataCenter));

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        

                        int dataCenterID = reader.GetInt32(0);
                        if (dataCenterID > 0)
                        {
                            connection.Close();
                            return dataCenterID;
                        }
                        else
                        {
                            connection.Close();
                            throw new Exception("Nenhum ambiente encontrado, entre em contato com o administrador");
                        }
                    }
                    return 0;
                }
            }
        }
        public int HttpPegarIDSistemaOperacional(string nomeSistemaOperacional, string versao, string distribuicao)
        {
            //var connectionString = "Server=172.20.1.50;Database=SistemaInventarioDev;User Id=uniteste;Password=devteste;";
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM SistemaOperacional WHERE NomeSistemaOperacional = @nomeSistemaOperacion AND Versao = @versao " +
                    "AND Distribuicao = @distribuicao", connection))
                {
                    command.Parameters.Add(new SqlParameter("nomeSistemaOperacion", nomeSistemaOperacional));
                    command.Parameters.Add(new SqlParameter("versao", versao));
                    command.Parameters.Add(new SqlParameter("distribuicao", distribuicao));

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int dataCenterID = reader.GetInt32(0);
                        if (dataCenterID > 0)
                        {
                            connection.Close();
                            return dataCenterID;
                        }
                        else
                        {
                            connection.Close();
                            throw new Exception("Nenhum ambiente encontrado, entre em contato com o administrador");
                        }
                    }
                    return 0;
                }
            }
        }
        public int HttpPegarIDBackup(string tipobackup, string descricaobackup)
        {
            //var connectionString = "Server=172.20.1.50;Database=SistemaInventarioDev;User Id=uniteste;Password=devteste;";
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM CategoriaBackup WHERE NomeCategoriaBackup = @nomeBackup AND Descricao = @descricao", connection))
                {
                    command.Parameters.Add(new SqlParameter("nomeBackup", tipobackup));
                    command.Parameters.Add(new SqlParameter("descricao", descricaobackup));

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int BackupID = reader.GetInt32(0);
                        if (BackupID > 0)
                        {
                            connection.Close();
                            return BackupID;
                        }
                        else
                        {
                            connection.Close();
                            throw new Exception("Nenhum ambiente encontrado, entre em contato com o administrador");
                        }
                    }
                    return 0;
                }
            }
        }

        public bool VerificaPorID(int id)
        {
            //var connectionString = "Server=172.20.1.50;Database=SistemaInventarioDev;User Id=uniteste;Password=devteste;";
            var connectionString = "Server=tcp:unidas.database.windows.net,1433;Initial Catalog=SistemaInventarioDev;Persist Security Info=False;User ID=estagio;Password=Unidas@20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (InvalidOperationException)
                {
                    throw new Exception("Algo de errado aconteceu entre em contato com o administrador");
                }
                using (SqlCommand command = new SqlCommand("SELECT IP FROM Servidor WHERE servidorID = @id", connection))
                {
                    command.Parameters.Add(new SqlParameter("id", id));

                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())

                        {
                            String ip = reader.GetString(0);
                            servidor = new Servidor() { IP = ip };
                        }
                        if (servidor.IP != null)
                        {
                            connection.Close();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
    }
}