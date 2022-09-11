using Microsoft.EntityFrameworkCore;
using UserCRUD.Data;
using UserCRUD.Data.Interface;
using UserCRUD.Model;

namespace UserCRUD.Data.DAO
{
    public class EscolaridadeDAO : IEscolaridadeDAO
    {
        //private EscolaridadeContext _context;
        private readonly DataContext _escolaridadeContext;

        public EscolaridadeDAO(DataContext dataContext)
        {
            _escolaridadeContext = dataContext;
        }

        public IEnumerable<Escolaridade> Read()
        {
            return _escolaridadeContext.Escolaridade.ToList();
        }

        public Escolaridade Read(string descricao)
        {
            return _escolaridadeContext.Escolaridade.FirstOrDefault(e => e.Descricao == descricao);
        }

        public Escolaridade Read(int id)
        {
            return _escolaridadeContext.Escolaridade.Find(id);
        }

        public void Create(Escolaridade escolaridade)
        {
            _escolaridadeContext.Escolaridade.Add(escolaridade);
            Save();
        }

        public void Delete(int escolaridadeID)
        {
            Escolaridade escolaridade = _escolaridadeContext.Escolaridade.Find(escolaridadeID);
            _escolaridadeContext.Escolaridade.Remove(escolaridade);
            Save();
        }

        public void Update(Escolaridade escolaridade)
        {
            _escolaridadeContext.Entry(escolaridade).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _escolaridadeContext.SaveChanges();
        }
    }
}
