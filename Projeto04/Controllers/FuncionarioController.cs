﻿using Projeto02.DAO;
using Projeto02.ExtensionMethods;
using Projeto02.Filtro;
using Projeto02.Models;
using Projeto02.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto02.Controllers
{
    [AutorizacaoFilter]
    public class FuncionarioController : Controller
    {
        private IList<Equipe> listaEquipe
        {
            get
            {
                var dao = new EquipeDAO();
                return dao.Lista();
            }
        }
        private IList<Cargo> listaCargo
        {
            get
            {
                var dao = new CargoDAO();
                return dao.Lista();
            }
        }
        //private IList<Funcionario> listaTipoPerfil
        //{
        //    get
        //    {
        //        var dao = new FuncionarioDAO();
        //        return dao.Lista();
        //    }
        //}
        //GET: Funcionario
        public ActionResult Index()
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            IList<Funcionario> funcionarios = dao.Lista();
            ViewBag.Funcionario = funcionarios.Where(r => r.TipoPerfil == TipoPerfil.Funcionario);
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Funcionario funcionario)
        {

            var random = new Random();
            FuncionarioDAO dao = new FuncionarioDAO();
            funcionario.CodigoVerificacao = random.Next();
            dao.Adiciona(funcionario);
            return View("Adiciona");
            //ViewBag.Equipe = listaEquipe;
            //ViewBag.Cargo = listaCargo;
            //ViewBag.TipoPerfil = listaTipoPerfil;

            //return View("Form", funcionario);
        }

        public ActionResult Form()
        {
            EquipeDAO dao = new EquipeDAO();
            IList<Equipe> equipe = dao.Lista();
            ViewBag.Equipe = equipe;

            CargoDAO daoo = new CargoDAO();
            IList<Cargo> cargo = daoo.Lista();
            ViewBag.Cargo = cargo;

            ViewBag.Funcionario = new Funcionario();

            ViewBag.ListaEnum = TipoPerfil.Administrador.ToSelectList();

            ViewBag.Equipe = listaEquipe;
            ViewBag.Cargo = listaCargo;
            //ViewBag.TipoPerfil = listaTipoPerfil;
            return View(new Funcionario());
        }

        public ActionResult Remover(int id)
        {
            var dao = new FuncionarioDAO();
            Funcionario funcionario = dao.BuscaPorIdWhere(id);
            dao.Remover(funcionario);
            return RedirectToAction("Index");
        }
        /*
        [Route("funcionario/{id}")]
        public ActionResult Visualiza()
        {
            var dao = new FuncionarioDAO();
            IList<Funcionario> funcionarios = dao.Lista();
            ViewBag.Funcionario = funcionarios;
            return View();
        }
        */

        public ActionResult Alterar(int id)
        {
            var daoo = new EquipeDAO();
            IList<Equipe> equipe = daoo.Lista();
            ViewBag.Equipe = equipe;

            var daooo = new CargoDAO();
            IList<Cargo> cargo = daooo.Lista();
            ViewBag.Cargo = cargo;

            var dao = new FuncionarioDAO();
            Funcionario funcionario = dao.BuscaPorId(id);
            ViewBag.Funcionario = funcionario;

            ViewBag.ListaEnum = TipoPerfil.Administrador.ToSelectList();

            return View(funcionario);
        }

        [HttpGet]
        public ActionResult Atualiza(int id)
        {
            var dao = new FuncionarioDAO();
            Funcionario funcionario = dao.BuscaPorId(id);
            return View(funcionario);
        }

        [HttpPost]
        public ActionResult Atualiza(int id, [Bind(Include = "Id, Nome, EquipeId, CargoId, Maquina, TipoPerfil")] Funcionario funcionario)
        {
            funcionario.Id = id;
            var dao = new FuncionarioDAO();
            dao.Atualiza(funcionario);
            return View();
        }

    }
}
