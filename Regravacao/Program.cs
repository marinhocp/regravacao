using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Regravacao.Repositories;
using Regravacao.Repositories.Funcionario;
using Regravacao.Services.Funcionario;
using Regravacao.Repositories.DetalhesDeErros;
using Regravacao.Repositories.Funcionario.Impl;
using Regravacao.Repositories.Regravacao;
using Regravacao.Services.Auth;
using Regravacao.Services.DetalhesDeErros;
using Regravacao.Services.Funcionario.Impl;
using Regravacao.Services.Regravacao;
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

                    // Repositório de Regravação (Mantido)
                    services.AddScoped<IRegravacaoRepository, RegravacaoRepository>();

                    // 🆕 REPOSITÓRIO: DETALHES DE ERROS
                    services.AddScoped<IDetalhesDeErrosRepository, DetalhesDeErrosRepository>();
                    services.AddScoped<IMaterialRepository, MaterialRepository>();
                    services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();                   


                    // --- SERVIÇOS ---

                    services.AddScoped<IRegravacaoService, RegravacaoService>();
                    services.AddScoped<IAuthService, AuthService>();
                    services.AddScoped<IDetalhesDeErrosService, DetalhesDeErrosService>();
                    services.AddScoped<IMaterialService, MaterialService>();
                    services.AddScoped<IFuncionarioService, FuncionarioService>();                    


                    // ✅ Forms
                    services.AddTransient<FrmMain>();
                    services.AddTransient<FrmRelatorios>();
                    services.AddTransient<FrmGraficosEstatistica>();
                    services.AddTransient<FrmChecklistErros>();
                    services.AddTransient<FrmConfiguracoes>();
                });
        }
    }
}