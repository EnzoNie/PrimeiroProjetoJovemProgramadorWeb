using JovemProgramadorWeb.Models;

namespace JovemProgramadorWeb.Data.Repositório.Interface
{
    public interface IAlunoRepositorio
    {
        List<Aluno> BuscarAlunos();

        void InserirAluno(Aluno aluno);
        void EditarAluno(Aluno aluno);

        void ExcluirAluno(Aluno aluno);

        Aluno BuscarAlunoPorId(int id);
    }
}
