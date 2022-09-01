using Microsoft.EntityFrameworkCore;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Infrastructure.Data;

public class EFContext : DbContext
{
    public EFContext(DbContextOptions<EFContext> options) : base(options) { }

    public DbSet<GrauParentesco> GrauParentesco { get; set; }

    public DbSet<Paciente> Paciente { get; set; }

    public DbSet<Responsavel> Responsavel { get; set; }

    public DbSet<Sessao> Sessao { get; set; }

    //protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //{
    //    if (modelBuilder == null)
    //    {
    //        return;
    //    }

    //    //TODO: Criar linhas instanciando as classes de mapeamento em Infrastructure.Data.Mappings
    //    //modelBuilder.Configurations.Add(new Map());

    //    base.OnModelCreating(modelBuilder);
    //}

    ///// <summary>
    ///// Não apagar! Corrige a referência ao provider do Entity Framework.
    ///// </summary>
    //private void EntityFrameworkFix()
    //{
    //    var instance = SqlProviderServices.Instance;
    //}
}