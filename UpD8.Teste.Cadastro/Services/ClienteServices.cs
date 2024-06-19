using UpD8.Teste.Cadastro.Data.Repositorios;
using UpD8.Teste.Cadastro.Models;

namespace UpD8.Teste.Cadastro.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepositorio iClienteRepositorio;

        public ClienteServices(IClienteRepositorio iClienteRepositorio)
        {
            this.iClienteRepositorio = iClienteRepositorio;
        }

        public Cliente Add(Cliente Cliente)
        {
            iClienteRepositorio.Add(Cliente);
            return Cliente;
        }

        public void Update(Cliente Cliente)
        {
            iClienteRepositorio.Update(Cliente);
        }

        public void Delete(int id)
        {
            var cliente = iClienteRepositorio.ByID(id);

            iClienteRepositorio.Delete(cliente);
        }

        public IEnumerable<Cliente> Get(Cliente Cliente)
        {
            return iClienteRepositorio.Get(Cliente).ToList();
        }

        public Cliente GetbyId(int id)
        {
            return iClienteRepositorio.ByID(id);
        }
    }

    public interface IClienteServices
    {
        Cliente Add(Cliente Cliente);

        void Update(Cliente Cliente);

        void Delete(int id);

        IEnumerable<Cliente> Get(Cliente Cliente);

        Cliente GetbyId(int id);
    }
}
