using UserCRUD.Model;

namespace UserCRUD.Data.Interface
{
    public interface IEscolaridadeDAO
    {
        IEnumerable<Escolaridade> Read();
        Escolaridade Read(string descricao);
        Escolaridade Read(int escolaridadeId);     
        void Create(Escolaridade escolaridade);
        void Delete(int escolaridadeID);
        void Update(Escolaridade escolaridade);
        void Save();
    }
}
