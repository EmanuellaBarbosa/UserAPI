using UserCRUD.Model;

namespace UserCRUD.Data.Interface
{
    public interface IUsuariosDAO
    {
        IEnumerable<Usuarios> Read();
        Usuarios ReadId(int usuarioId);
        Usuarios Read(string cpf);
        void Create(Usuarios usuario);
        void Delete(int usuarioID);
        void Update(Usuarios usuario);
        void Save();
    }
}
