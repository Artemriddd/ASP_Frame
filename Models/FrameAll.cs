using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFrame.Models
{
    public class FrameAll
    {
        private double insideBelt;
        private double outsideBelt;
        private double frameWall;
        private double ticknessinsideBelt;
        private double ticknessoutsideBelt;
        private double ticknessframeWall;
        private double skinTickness;
        private float skinCoef;
        private double skinWidth;
        private double skinHeight;
        private double area;
        private int skinElasticModule;
        private int skinSigma02;
        private int skinSigmaB;
        private int frameElasticModule;
        private int frameSigma02;
        private int frameSigmaB;

        public string skinBuck { get; set; }
        public double SetinsideBelt
        {
            get
            {
                return insideBelt;
            }
            set
            {
                if (value > 0)
                {
                    insideBelt = value;
                }
            }
        }
        public double SetoutsideBelt
        {
            get
            {
                return outsideBelt;
            }
            set
            {
                if (value > 0)
                {
                    outsideBelt = value;
                }
            }
        }
        public double SetframeWall
        {
            get
            {
                return frameWall;
            }
            set
            {
                if (value > 0)
                {
                    frameWall = value;
                }
            }
        }
        public double SetticknessinsideBelt
        {
            get
            {
                return ticknessinsideBelt;
            }
            set
            {
                if (value > 0)
                {
                    ticknessinsideBelt = value;
                }
            }
        }
        public double SetticknessoutsideBelt
        {
            get
            {
                return ticknessoutsideBelt;
            }
            set
            {
                if (value > 0)
                {
                    ticknessoutsideBelt = value;
                }
            }
        }
        public double SetticknessframeWall
        {
            get
            {
                return ticknessframeWall;
            }
            set
            {
                if (value > 0)
                {
                    ticknessframeWall = value;
                }
            }
        }

        public double SetSkinTickness
        {
            get
            {
                return skinTickness;
            }
            set
            {
                if (value > 0)
                {
                    skinTickness = value;
                }
            }
        }
        public float SetskinCoef
        {
            get
            {
                return skinCoef;
            }
            set
            {
                if (value > 0)
                {
                    skinCoef = value;
                }
            }
        }

        public double SetskinWidth
        {
            get
            {
                return skinWidth;
            }
            set
            {
                if (value > 0)
                {
                    skinWidth = value;
                }
            }
        }
        public double SetskinHeight
        {
            get
            {
                return skinHeight;
            }
            set
            {
                if (value > 0)
                {
                    skinHeight = value;
                }
            }
        }

        public double SetArea
        {
            get
            {
                return area;
            }
            private set
            {
                if (value > 0)
                {
                    area = value;
                }
            }
        }
        public int SetskinElasticModule
        {
            get
            {
                return skinElasticModule;
            }
            set
            {
                if (value > 0)
                {
                    skinElasticModule = value;
                }
            }
        }
        public int SetskinSigma02
        {
            get
            {
                return skinSigma02;
            }
            set
            {
                if (value > 0)
                {
                    skinSigma02 = value;
                }
            }
        }
        public int SetskinSigmaB
        {
            get
            {
                return skinSigmaB;
            }
            set
            {
                if (value > 0)
                {
                    skinSigmaB = value;
                }
            }
        }
        public int SetframeElasticModule
        {
            get
            {
                return frameElasticModule;
            }
            set
            {
                if (value > 0)
                {
                    frameElasticModule = value;
                }
            }
        }
        public int SetframeSigma02
        {
            get
            {
                return frameSigma02;
            }
            set
            {
                if (value > 0)
                {
                    frameSigma02 = value;
                }
            }
        }
        public int SetframeSigmaB
        {
            get
            {
                return frameSigmaB;
            }
            set
            {
                if (value > 0)
                {
                    frameSigmaB = value;
                }
            }
        }
        public int SetskinNormalForce { get; set; }

        public int SetframeNormalForce { get; set; }

        public int SetframeShearForce { get; set; }

        public int SetframeMoment { get; set; }

        // Результаты
        public double criticalSkinSigma { get; set; }
        public double criticalSigma { get; set; }
        public double criticalForce { get; set; }
        public double tau { get; set; }
        public double sigmaMomentInsideBelt { get; set; }
        public double sigmaN { get; set; }
        public double criticalInsideBeltSigma { get; set; }
        public double sigmaMomentOutsideBelt { get; set; }
        public double Inertion { get; set; }
        public double CentreInertion { get; set; }

        public double sigmaInsideBelt { get; set; }

        public double sigmaOutsideBelt { get; set; }

        public double sigmaVonMis { get; set; }

        public double safetyInsideBelt { get; set; }

        public double safetyOutsideBelt { get; set; }

        public double safetyVonMis { get; set; }

        public double safetyBuclingInsideBelt { get; set; }
        public double safetyFullBucling { get; set; }
        public double GetInertion()
        {
            double inertion = Math.Round(Math.Pow(SetticknessinsideBelt, 3) * SetinsideBelt / 12 + (SetinsideBelt * SetticknessinsideBelt * Math.Pow(SetframeWall - GetCenterOrigin() - SetticknessinsideBelt / 2, 2)) + Math.Pow(SetticknessoutsideBelt, 3) * SetoutsideBelt / 12 + (SetoutsideBelt * SetticknessoutsideBelt * Math.Pow(GetCenterOrigin() - SetticknessoutsideBelt / 2, 2)) + Math.Pow(SetframeWall, 3) * SetticknessframeWall / 12 + (SetframeWall * SetticknessframeWall * Math.Pow(GetCenterOrigin() - SetframeWall / 2, 2)),0);
            return inertion;
        }
        public double GetCenterOrigin()
        {
            SetArea = SetinsideBelt * SetticknessinsideBelt + SetoutsideBelt * SetticknessoutsideBelt + SetticknessframeWall * SetframeWall;
            double statInertion = (SetinsideBelt * SetticknessinsideBelt) * (SetframeWall - SetticknessinsideBelt / 2) + (SetticknessframeWall * SetframeWall) * SetframeWall / 2 + (SetoutsideBelt * SetticknessoutsideBelt) * SetticknessoutsideBelt / 2;
            double centerOrigin = statInertion / area;
            return centerOrigin;
        }
        public double GetInertionSkin()
        {
            double inertion = 30 * SetSkinTickness * Math.Pow(SetSkinTickness, 3) / 12 + 30 * SetSkinTickness * SetSkinTickness * Math.Pow(GetCenterOriginSkin() - SetSkinTickness / 2, 2) + Math.Pow(SetticknessinsideBelt, 3) * SetinsideBelt / 12 + (SetinsideBelt * SetticknessinsideBelt * Math.Pow(SetframeWall + SetSkinTickness - GetCenterOriginSkin() - (SetticknessinsideBelt / 2), 2)) + Math.Pow(SetticknessoutsideBelt, 3) * SetoutsideBelt / 12 + (SetoutsideBelt * SetticknessoutsideBelt * Math.Pow(SetSkinTickness + (SetticknessoutsideBelt / 2) - GetCenterOriginSkin(), 2)) + Math.Pow(SetframeWall, 3) * SetticknessframeWall / 12 + (SetframeWall * SetticknessframeWall * Math.Pow((SetframeWall / 2) + SetSkinTickness - GetCenterOriginSkin(), 2));
            return inertion;
        }
        public double GetCenterOriginSkin()
        {
            SetArea = SetinsideBelt * SetticknessinsideBelt + SetoutsideBelt * SetticknessoutsideBelt + SetticknessframeWall * SetframeWall + 30 * SetSkinTickness * SetSkinTickness;
            double statInertion = SetinsideBelt * SetticknessinsideBelt * (SetframeWall - SetticknessinsideBelt / 2) + (SetticknessframeWall * SetframeWall) * SetframeWall / 2 + (SetoutsideBelt * SetticknessoutsideBelt) * SetticknessoutsideBelt / 2 - 30 * SetSkinTickness * SetSkinTickness * SetSkinTickness / 2;
            double centerOrigin = SetSkinTickness + statInertion / area;
            return centerOrigin;
        }
    }
}
