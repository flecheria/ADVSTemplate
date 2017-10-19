using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// using alias directive for AdvanceSteel
using Autodesk.AdvanceSteel.Runtime;
using Autodesk.AdvanceSteel.Profiles;
using Autodesk.AdvanceSteel.ConstructionTypes;
using Autodesk.AdvanceSteel.Arrangement;
using Autodesk.AdvanceSteel.Contours;

using ASGeo = Autodesk.AdvanceSteel.Geometry;
using ASMod = Autodesk.AdvanceSteel.Modelling;
using ASDoc = Autodesk.AdvanceSteel.DocumentManagement;
using ASCad = Autodesk.AdvanceSteel.CADAccess;
using ASdb = Autodesk.AdvanceSteel.CADLink.Database;

// using alias directive for Autocad
using Autodesk.AutoCAD.EditorInput;
using ACApp = Autodesk.AutoCAD.ApplicationServices;

[assembly: CommandClass(typeof(ADVSTemplate.Command))]
namespace ADVSTemplate
{
    class Command
    {
        [CommandMethodAttribute("TEST_GROUP", "TestCommand", "TestCommand",
                                CommandFlags.Modal | CommandFlags.UsePickSet | CommandFlags.Redraw)]
        public void Create()
        {
            ASDoc.DocumentManager.LockCurrentDocument();
            ASCad.Transaction t = ASCad.TransactionManager.StartTransaction();

            // your code here
            Editor ed = ACApp.Core.Application.DocumentManager.MdiActiveDocument.Editor;
            ed.WriteMessage("hello CreateConnectors");

            t.Commit();
            ASDoc.DocumentManager.UnlockCurrentDocument();
        }

        // custom function here
        private void CreateStraightBeam ()
        {
            ProfileName pn = new ProfileName();
            ProfilesManager.GetProfTypeAsDefault("I", out pn);

            ASGeo.Point3d s1 = ASGeo.Point3d.kOrigin;
            ASGeo.Point3d e1 = new ASGeo.Point3d(0, 0, 3500);

            ASMod.StraightBeam b1 = new ASMod.StraightBeam(pn.Name, s1, e1, ASGeo.Vector3d.kXAxis);
            b1.WriteToDb();

            ASGeo.Point3d s2 = new ASGeo.Point3d(0, 0, 3500);
            ASGeo.Point3d e2 = new ASGeo.Point3d(0, 3000, 3500);

            ASMod.StraightBeam b2 = new ASMod.StraightBeam("AISC 14.1 W Shape#@§@#W10x33", s2, e2, ASGeo.Vector3d.kXAxis);
            // ASMod.StraightBeam b2 = new ASMod.StraightBeam("HEA  DIN18800-1#@§@#HEA200", s2, e2, ASGeo.Vector3d.kXAxis);
            b2.WriteToDb();
        }

    }
}
