﻿using LanchesMac.Models;
using LanchesMac.Repository.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers;

public class LancheController : Controller
{
    private readonly ILancheRepository _lancheRepository;

    public LancheController(ILancheRepository lancheRepository)
    {
        _lancheRepository = lancheRepository;
    }

    public IActionResult List(string categoria)
    {
        IEnumerable<Lanche> lanches;
        string categoriaAtual = string.Empty;


        if (string.IsNullOrEmpty(categoria))
        {
            lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
            categoriaAtual = "Todos os Lanches";
        }
        else
        {
            if (string.Equals("Normal", categoria, StringComparison.OrdinalIgnoreCase))
            {
                lanches = _lancheRepository.Lanches
                    .Where(l => l.Categoria.CategoriaNome.Equals("Normal"))
                    .OrderBy(l => l.Nome);
            }
            else
            {
                lanches = _lancheRepository.Lanches
                    .Where(l => l.Categoria.CategoriaNome.Equals("Natural"))
                    .OrderBy(l => l.Nome);
            }
            
        }
        var lancheListViewModel = new LancheListViewModel
        {
            LanchesVM = lanches,
            CategoriaAtual = categoriaAtual,
        };

        return View(lancheListViewModel);







        //var lancheListViewModel = new LancheListViewModel();
        //lancheListViewModel.LanchesVM = _lancheRepository.Lanches;
        //lancheListViewModel.CategoriaAtual = "Categoria ATUAL";

        //var lanches = _lancheRepository.Lanches.ToList();
        //var totalLanches = lanches.Count();

        //ViewData["Titulo"] = "Todos os lanches";
        //ViewData["DAta"] = DateTime.Now;
        //ViewBag.Total = "Total de lanches : ";
        //ViewBag.TotalLanches = totalLanches;

        //return View(lanches);
    }
}
