using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using UpD8.Teste.Cadastro.Models;

namespace UpD8.Teste.Cadastro.Data.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Cliente Cliente)
        {

            _context.Cliente.Add(Cliente);
            _context.SaveChanges();
        }

        public void Update(Cliente Cliente)
        {
            _context.Entry(Cliente).State = EntityState.Modified;
        }

        public void Delete(Cliente Cliente)
        {
            _context.Cliente.Remove(Cliente);
            _context.SaveChanges();
        }

        public Cliente ByID(int id)
        {
            return _context.Cliente.Find(id);
        }

        public IEnumerable<Cliente> Get(Cliente Cliente)
        {

            string sql = $"EXEC PRD_PESQUISA ";

            if (Cliente.CPF != null)
                sql += $"@CPF = '{Cliente.CPF}' ,";

            if (Cliente.Nome != null)
                sql += $"@Nome = '{Cliente.Nome}' ,";

            if (Cliente.DataNasciemnto != null)
                sql += $"@DataNasciemnto = '{Cliente.DataNasciemnto}',";

            if (Cliente.Sexo != null)
                sql += $"@Sexo = '{Cliente.Sexo}' ,";

            if (Cliente.Estado != null)
                sql += $"@Estado = '{Cliente.Estado}' ,";

            if (Cliente.Cidade != null)
                sql += $"@Cidade = '{Cliente.Cidade}' ,";

            sql += "*";


           
            return _context.Cliente.FromSqlRaw(sql.Replace(",*","").Replace("*", "")).ToList();

        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }

    public interface IClienteRepositorio
    {
        void Add(Cliente Cliente);
        void Update(Cliente Cliente);
        void Delete(Cliente Cliente);

        public Cliente ByID(int id);
        IEnumerable<Cliente> Get(Cliente Cliente);
        void Salvar();
    }
}
