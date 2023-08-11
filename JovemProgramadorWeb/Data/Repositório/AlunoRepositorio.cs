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


    }
}
