using GerenciadorCondominios.BLL.Models;
using GerenciadorCondominios.DAL.Context;
using GerenciadorCondominios.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GerenciadorCondominios.DAL.Repositorios
{
    public class UsuarioRepositorio : RepositorioGenerico<Usuario>, IUsuarioRepositorio
    {
        private readonly DataContext _context;
        private readonly UserManager<Usuario> _gerenciadoUsuarios;
        private readonly SignInManager<Usuario> _gerenciadorLogin;
        public UsuarioRepositorio(DataContext context, UserManager<Usuario> gerenciadoUsuarios, SignInManager<Usuario> gerenciadorLogin) : base(context)
        {
            _context = context;
            _gerenciadoUsuarios = gerenciadoUsuarios;
            _gerenciadorLogin = gerenciadorLogin;           
        }

        public async Task<IdentityResult> CriarUsuario(Usuario usuario, string senha)
        {
            try
            {
                return await _gerenciadoUsuarios.CreateAsync(usuario, senha);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public async Task IncluirUsuarioEmFuncao(Usuario usuario, string funcao)
        {
            try
            {
                await _gerenciadoUsuarios.AddToRoleAsync(usuario, funcao);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task LogarUsuario(Usuario usuario, bool lembrar)
        {
            try
            {
                await _gerenciadorLogin.SignInAsync(usuario, lembrar);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int VerificarSeExisteRegistro()
        {
            try
            {
                return _context.Users.Count();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
