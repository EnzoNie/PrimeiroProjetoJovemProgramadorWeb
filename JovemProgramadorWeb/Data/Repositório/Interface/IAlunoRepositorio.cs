using JovemProgramadorWeb.Models;

namespace JovemProgramadorWeb.Data.Repositório.Interface
{
    public interface IAlunoRepositorio
    {
        List<Aluno> BuscarAlunos();

        void InserirAluno(Aluno aluno);
    }
}
