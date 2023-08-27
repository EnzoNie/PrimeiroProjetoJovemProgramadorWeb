using JovemProgramadorWeb.Data.Repositório.Interface;
using JovemProgramadorWeb.Models;

namespace JovemProgramadorWeb.Data.Repositório
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly BancoContexto _bancoContexto;

        public AlunoRepositorio(BancoContexto bancoContexto)
        {
            _bancoContexto = bancoContexto;
        }

        public List<Aluno> BuscarAlunos()
        {
            return _bancoContexto.Aluno.ToList();
        }
 
        public void InserirAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Add(aluno);
            _bancoContexto.SaveChanges();
        }
        public void EditarAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Update(aluno);
            _bancoContexto.SaveChanges();
        }
        public void ExcluirAluno(Aluno aluno)
        {
            _bancoContexto.Aluno.Remove(aluno);
            _bancoContexto.SaveChanges();
        }


        public Aluno BuscarAlunoPorId(int id)
        {
            return _bancoContexto.Aluno.FirstOrDefault(x=>x.Id == id);
        }

        public bool ValidarLogin(string email, string senha)
        {
            var resultado = _bancoContexto.Aluno.FirstOrDefault(x => x.Email == email && x.Senha == senha);

            if (resultado == null)
            {
                throw new Exception("Email ou senha inválidos!");
            }
            return true;
        }
    }
}
