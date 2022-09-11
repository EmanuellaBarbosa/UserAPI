using Microsoft.EntityFrameworkCore;
using UserCRUD.Data;
using UserCRUD.Data.Interface;
using UserCRUD.Model;

namespace UserCRUD.Data.DAO
{
    public class UsuariosDAO : IUsuariosDAO
    {
        private readonly DataContext _usuariosContext;

        public UsuariosDAO(DataContext dataContext)
        {
            _usuariosContext = dataContext;
        }

        public IEnumerable<Usuarios> Read()
        {
            return _usuariosContext.Usuarios.ToList();
        }

        public Usuarios ReadId(int id)
        {
            return _usuariosContext.Usuarios.Find(id);
        }

        public Usuarios Read(string cpf)
        {
            return _usuariosContext.Usuarios.FirstOrDefault(e => e.cpf == cpf);
        }

        public void Create(Usuarios usuarios)
        {
            _usuariosContext.Usuarios.Add(usuarios);
            Save();
        }

        public void Delete(int usuariosID)
        {
            Usuarios usuarios = _usuariosContext.Usuarios.Find(usuariosID);
            _usuariosContext.Usuarios.Remove(usuarios);
            Save();
        }

        public void Update(Usuarios usuarios)
        {
            _usuariosContext.Entry(usuarios).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _usuariosContext.SaveChanges();
        }
    }
}
