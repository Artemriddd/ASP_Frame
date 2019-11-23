using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFrame.Models;

namespace MyFrame.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(FrameAll model)
        {
            model.criticalSkinSigma = BucklingSkin.Buckling(model.SetskinCoef, model.SetskinElasticModule, model.SetskinHeight, model.SetSkinTickness);

            if (model.criticalSkinSigma > model.SetskinSigma02)
            {
                model.criticalForce = model.SetskinSigma02 * model.SetSkinTickness * model.SetskinWidth;
            }
            else
            {
                model.criticalForce = model.criticalSkinSigma * model.SetSkinTickness * model.SetskinWidth;
            }
            if (-model.criticalForce < model.SetskinNormalForce)
            {
                model.skinBuck = "Нет";
                model.Inertion = Math.Round(model.GetInertion(),0);
                model.CentreInertion = Math.Round(model.GetCenterOrigin(),2);
                model.tau = Math.Round(model.SetframeShearForce / (model.SetticknessframeWall * model.SetframeWall),2);
                model.sigmaMomentInsideBelt = Math.Round(model.SetframeMoment * (model.GetCenterOrigin() - model.SetframeWall) / model.GetInertion(),2);
                model.sigmaMomentOutsideBelt = Math.Round(model.SetframeMoment * model.GetCenterOrigin() / model.GetInertion(),2);
                model.sigmaN = Math.Round(model.SetframeNormalForce / model.SetArea,2);
                model.sigmaInsideBelt = model.sigmaMomentInsideBelt + model.sigmaN;
                model.sigmaOutsideBelt = model.sigmaMomentOutsideBelt + model.sigmaN;
                model.sigmaVonMis = Math.Round(Math.Sqrt(Math.Pow(Math.Max(Math.Abs(model.sigmaInsideBelt), Math.Abs(model.sigmaOutsideBelt)), 2) + 3 * Math.Pow(model.tau, 2)),2);
                model.safetyInsideBelt = Math.Round(Math.Abs(model.SetskinSigmaB / model.sigmaInsideBelt),2);
                model.safetyOutsideBelt = Math.Round(Math.Abs(model.SetskinSigmaB / model.sigmaOutsideBelt),2);
                model.safetyVonMis = Math.Round(model.SetskinSigmaB / model.sigmaVonMis,2);
                if (model.sigmaInsideBelt < 0)
                {
                    
                    model.criticalInsideBeltSigma = BucklingSkin.Buckling(0.4, model.SetframeElasticModule, model.SetinsideBelt, model.SetticknessinsideBelt);

                    if (model.criticalInsideBeltSigma > model.SetskinSigma02)
                    {
                       
                        model.safetyBuclingInsideBelt = Math.Round(model.SetskinSigma02 / Math.Abs(model.sigmaInsideBelt), 2);
                    }
                    else
                    {
                        
                        model.safetyBuclingInsideBelt = Math.Round(model.criticalInsideBeltSigma / Math.Abs(model.sigmaInsideBelt), 2);
                    }
                }
                if (model.sigmaN < 0)
                {
                    model.criticalSigma = Math.Round(2 * Math.PI * model.SetframeElasticModule * model.GetInertionSkin() /  (model.SetArea * Math.Pow(model.SetskinHeight,2)),2);

                    if (model.criticalSigma > model.SetframeSigma02)
                    {
                        model.criticalSigma = model.SetframeSigma02;
                        model.safetyFullBucling = Math.Round(model.criticalSigma / Math.Abs(model.sigmaN), 2);
                    }
                    else
                    {
                        model.safetyFullBucling = Math.Round(model.criticalSigma / Math.Abs(model.sigmaN), 2);
                    }
                }
            }
            else
            {
                model.skinBuck = "Да! на " + Math.Round(Math.Abs(model.criticalForce / model.SetskinNormalForce * 100),1) + "% от Рр";
                model.Inertion = Math.Round(model.GetInertionSkin(),0);
                model.CentreInertion = Math.Round(model.GetCenterOriginSkin(),2); 
                model.SetframeNormalForce += 2 * (model.SetskinNormalForce + (int)model.criticalForce);    
                model.tau = Math.Round(model.SetframeShearForce / (model.SetticknessframeWall * model.SetframeWall),2);
                model.sigmaMomentInsideBelt = Math.Round(model.SetframeMoment * (model.GetCenterOriginSkin() - model.SetframeWall - model.SetSkinTickness) / model.GetInertionSkin(),2);
                model.sigmaMomentOutsideBelt = Math.Round(model.SetframeMoment * model.GetCenterOriginSkin() / model.GetInertionSkin(),2);
                model.sigmaN = Math.Round(model.SetframeNormalForce / model.SetArea,2);
                model.sigmaInsideBelt = model.sigmaMomentInsideBelt + model.sigmaN;
                model.sigmaOutsideBelt = model.sigmaMomentOutsideBelt + model.sigmaN;
                model.sigmaVonMis = Math.Round(Math.Sqrt(Math.Pow(Math.Max(Math.Abs(model.sigmaInsideBelt), Math.Abs(model.sigmaOutsideBelt)), 2) + 3 * Math.Pow(model.tau, 2)),2);
                model.safetyInsideBelt = Math.Round(Math.Abs(model.SetskinSigmaB / model.sigmaInsideBelt),2);
                model.safetyOutsideBelt = Math.Round(Math.Abs(model.SetskinSigmaB / model.sigmaOutsideBelt),2);
                model.safetyVonMis = Math.Round(model.SetskinSigmaB / model.sigmaVonMis,2);
                if (model.sigmaInsideBelt < 0)
                { 
                    model.criticalInsideBeltSigma = BucklingSkin.Buckling(0.4, model.SetframeElasticModule, model.SetinsideBelt, model.SetticknessinsideBelt);

                    if (model.criticalInsideBeltSigma > model.SetskinSigma02)
                    {  
                        model.safetyBuclingInsideBelt = Math.Round(model.SetskinSigma02 / Math.Abs(model.sigmaInsideBelt), 2);
                    }
                    else
                    {
                        model.safetyBuclingInsideBelt = Math.Round(model.criticalInsideBeltSigma / Math.Abs(model.sigmaInsideBelt), 2);
                    }
                }
                if (model.sigmaN < 0)
                {
                    model.criticalSigma = Math.Round(2 * Math.PI * model.SetframeElasticModule * model.GetInertionSkin() / (model.SetArea * Math.Pow(model.SetskinHeight, 2)),2);

                    if (model.criticalSigma > model.SetframeSigma02)
                    {
                        model.criticalSigma = model.SetframeSigma02;
                        model.safetyFullBucling = Math.Round(model.criticalSigma / Math.Abs(model.sigmaN), 2);
                    }
                    else
                    {
                        model.safetyFullBucling = Math.Round(model.criticalSigma / Math.Abs(model.sigmaN), 2);
                    }
                }
            }
            return View(model);
        }
    }
}