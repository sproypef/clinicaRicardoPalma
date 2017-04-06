﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.TP2.WEB.Models;
using System.Web.Helpers;
using UPC.TP2.WEB.ViewModels;

namespace UPC.TP2.WEB.Controllers
{
    public class PlanSaludController : Controller
    {
        private BDCLINICAEntities db = new BDCLINICAEntities();

        //
        // GET: /PlanSalud/

        public ActionResult Index()
        {
            //B:Get plan salud
            int id_plan_salud = 0; //Consider that if [id_plan_salud] does not exist, it is 0: Optionality change for -99 
            id_plan_salud = Int32.Parse(Request["plan_salud_action_select_plan"] ?? (TempData["pla_sal.id_plan_salud"] != null ? TempData["pla_sal.id_plan_salud"].ToString() : "-1")); //-1: All record by default
            ViewData["id_plan_salud"] = id_plan_salud.ToString();
            //E:Get plan salud

            //Get messages from others actions : When redirect to here
            ViewBag.Message = TempData["pla_sal.Message"] != null ? TempData["pla_sal.Message"].ToString() : String.Empty;

            PlanSaludViewModel pvm = new PlanSaludViewModel()
            {
                PLANES_DE_SALUD = db.T_PLAN_DE_SALUD.ToList(),
                PLAN_DE_SALUD = db.T_PLAN_DE_SALUD.Find(id_plan_salud) ?? new T_PLAN_DE_SALUD()
            };
            return View(pvm);
        }

        //
        // GET: /PlanSalud/Details/5

        public ActionResult Details(int id = 0)
        {
            T_PLAN_DE_SALUD t_plan_de_salud = db.T_PLAN_DE_SALUD.Find(id);
            if (t_plan_de_salud == null)
            {
                return HttpNotFound();
            }
            return View(t_plan_de_salud);
        }

        //
        // GET: /PlanSalud/Create

        public ActionResult Create()
        {
            ViewBag.id_estrategia_comercial = new SelectList(db.T_ESTRATEGIA_COMERCIAL, "id_estrategia_comercial", "nombre");
            ViewBag.id_base_legal = new SelectList(db.T_BASE_LEGAL, "id_base_legal", "nombre_normativa");
            ViewBag.id_base_financiera = new SelectList(db.T_BASE_FINANCIERA, "id_base_financiera", "descripcion");
            ViewBag.id_investigacion_comercial = new SelectList(db.T_INVESTIGACION_COMERCIAL, "id_investigacion_comercial", "nombre");
            return View();
        }

        //
        // POST: /PlanSalud/Create

        [HttpPost]
        public ActionResult Create(T_PLAN_DE_SALUD planSalud)
        {

            if (ModelState.IsValid)
            {
                db.T_PLAN_DE_SALUD.Add(planSalud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_investigacion_comercial = new SelectList(db.T_INVESTIGACION_COMERCIAL, "id_investigacion_comercial", "nombre", planSalud.id_investigacion_comercial);
            return View(planSalud);
        }

        //
        // GET: /PlanSalud/Edit/5

        public ActionResult Edit(int id = 0)
        {
            T_PLAN_DE_SALUD t_plan_de_salud = db.T_PLAN_DE_SALUD.Find(id);
            if (t_plan_de_salud == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_estrategia_comercial = new SelectList(db.T_ESTRATEGIA_COMERCIAL, "id_estrategia_comercial", "nombre");
            ViewBag.id_investigacion_comercial = new SelectList(db.T_INVESTIGACION_COMERCIAL, "id_investigacion_comercial", "nombre", t_plan_de_salud.id_investigacion_comercial);
            return View(t_plan_de_salud);
        }

        //
        // POST: /PlanSalud/Edit/5

        [HttpPost]
        public ActionResult Edit(T_PLAN_DE_SALUD t_plan_de_salud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_plan_de_salud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_investigacion_comercial = new SelectList(db.T_INVESTIGACION_COMERCIAL, "id_investigacion_comercial", "nombre", t_plan_de_salud.id_investigacion_comercial);
            return View(t_plan_de_salud);
        }

        //
        // GET: /PlanSalud/Delete/5

        public ActionResult Delete(int id = 0)
        {
            T_PLAN_DE_SALUD t_plan_de_salud;

                t_plan_de_salud = db.T_PLAN_DE_SALUD.Find(id);

                if (t_plan_de_salud == null)
                {
                    return HttpNotFound();
                }

            return View(t_plan_de_salud);
        }

        //
        // POST: /PlanSalud/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            T_PLAN_DE_SALUD t_plan_de_salud = db.T_PLAN_DE_SALUD.Find(id);
            db.T_PLAN_DE_SALUD.Remove(t_plan_de_salud);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}