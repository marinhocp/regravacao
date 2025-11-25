using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Regravacao.Repositories;
using Regravacao.Repositories.Conferente;
using Regravacao.Repositories.Conferente.Impl;
using Regravacao.Repositories.Configuracoes;
using Regravacao.Repositories.CustoDeQuem;
using Regravacao.Repositories.DetalhesDeErros;
using Regravacao.Repositories.Empresa;
using Regravacao.Repositories.Funcionario;
using Regravacao.Repositories.Funcionario.Impl;
using Regravacao.Repositories.MotivosPrincipais;
using Regravacao.Repositories.Prioridade;
using Regravacao.Repositories.Regravacao;
using Regravacao.Repositories.Solicitante;
using Regravacao.Repositories.Status;
using Regravacao.Services.Auth;
using Regravacao.Services.Calculo;
using Regravacao.Services.Conferente;
using Regravacao.Services.Configuracoes;
using Regravacao.Services.Cores;
using Regravacao.Services.CustoDeQuem;
using Regravacao.Services.DetalhesDeErros;
using Regravacao.Services.Empresa;
using Regravacao.Services.Finalizador;
using Regravacao.Services.MotivosPrincipais;
using Regravacao.Services.Prioridade;
using Regravacao.Services.Regravacao;
using Regravacao.Services.Solicitante;
using Regravacao.Services.Status;
using Regravacao.Views;
using Supabase;

namespace Regravacao
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            var mainForm = ServiceProvider.GetRequiredService<FrmMain>();
            Application.Run(mainForm);
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // ✅ SUPABASE CONFIG
                    var supabaseUrl = "https://sgoajibauoutfnsltkha.supabase.co";
                    var supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InNnb2FqaWJhdW91dGZuc2x0a2hhIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NjIyNjU5OTUsImV4cCI6MjA3Nzg0MTk5NX0.iObA13qBTKtNSmQIawj1KFZhzl9a0YUiHsNK69HkWKU";
                    var supabase = new Client(supabaseUrl, supabaseKey);
                    services.AddSingleton(supabase);

                    // --- REPOSITÓRIOS ---
                    services.AddScoped<IRegravacaoRepository, RegravacaoRepository>();
                    services.AddScoped<IDetalhesDeErrosRepository, DetalhesDeErrosRepository>();
                    services.AddScoped<IMaterialRepository, MaterialRepository>();
                    services.AddScoped<IFinalizadorRepository, FinalizadorRepository>();
                    services.AddScoped<IConferenteRepository, ConferenteRepository>();
                    services.AddScoped<ISolicitanteRepository, SolicitanteRepository>();
                    services.AddScoped<IRegravacaoRepository, RegravacaoRepository>();
                    services.AddScoped<IConfiguracoesCustoRepository, ConfiguracoesCustoRepository>();
                    services.AddScoped<IEmpresaRepository, EmpresaRepository>();
                    services.AddScoped<IMotivosPrincipaisRepository, MotivosPrincipaisRepository>();
                    services.AddScoped<ICustoDeQuemRepository, CustoDeQuemRepository>();
                    services.AddScoped<IPrioridadeRepository, PrioridadeRepository>();
                    services.AddScoped<IStatusRepository, StatusRepository>();
                    services.AddScoped<ICoresRepository, CoresRepository>();                 


                    // --- SERVIÇOS ---
                    services.AddScoped<IRegravacaoService, RegravacaoService>();
                    services.AddScoped<IAuthService, AuthService>();
                    services.AddScoped<IDetalhesDeErrosService, DetalhesDeErrosService>();
                    services.AddScoped<IMaterialService, MaterialService>();
                    services.AddScoped<IFinalizadorService, FinalizadorService>();
                    services.AddScoped<IConferenteService, ConferenteService>();
                    services.AddScoped<ISolicitanteService, SolicitanteService>();
                    services.AddScoped<IRegravacaoService, RegravacaoService>();
                    services.AddScoped<IConfiguracoesCustoService, ConfiguracoesCustoService>();
                    services.AddScoped<IEmpresaService, EmpresaService>();
                    services.AddScoped<IMotivosPrincipaisService, MotivosPrincipaisService>();
                    services.AddScoped<ICustoDeQuemService, CustoDeQuemService>();
                    services.AddScoped<IPrioridadeService, PrioridadeService>();
                    services.AddScoped<IStatusService, StatusService>();
                    services.AddScoped<ICoresService, CoresService>();



                    // ✅ Forms
                    services.AddTransient<FrmMain>();
                    services.AddTransient<FrmRelatorios>();
                    services.AddTransient<FrmGraficosEstatistica>();
                    services.AddTransient<FrmChecklistErros>();
                    services.AddTransient<FrmConfiguracoes>();
                    services.AddTransient<CalculadoraDeCusto>();                    

                });
        }
    }
}