using BotTemplate.UserApi;
using BotTemplate.UserApi.Interfaces;
using BotTemplate.UserApi.Managers;
using System;
using System.Threading;
using System.Diagnostics;

namespace Plugin
{
    public class Plugin : IPlugin
    {
        Stopwatch sw_OM = new Stopwatch();
        Stopwatch tickTime = new Stopwatch();
        public string Description
        {
            get
            {
                return "A test plugin";
            }
        }

        public string Name
        {
            get
            {
                return "Test";
            }
        }

        public void OpenForm()
        {
            // do nuthing
        }

        public void Pulse()
        {
          
          //  
        //    UnsortedFunctions.WriteToConsole("Pulse");
            if (!sw_OM.IsRunning) sw_OM.Restart();
            if (sw_OM.Elapsed > TimeSpan.FromMilliseconds(20))
            {
                ObjectManager.Read();
               
               
                sw_OM.Restart();
            }
            if (ObjectManager.Objects[0].Name == null) return;
            
            Structs.ObjectInfo Me = ObjectManager.Objects[0];
            Structs.ObjectInfo Target = ObjectManager.Objects[1];
            Structs.Vector3 MeVec = new BotTemplate.Constants.Structs.Vector3();
            MeVec.X = Me.X; MeVec.Y = Me.Y; MeVec.Z = Me.Z +1;
            Structs.Vector3 TargetVec = new BotTemplate.Constants.Structs.Vector3();
            TargetVec.X = Target.X; TargetVec.Y = Target.Y; TargetVec.Z = Target.Z + 1;
            if (Target.Name != null)
            {
                int traceResult = 99;
                UnsortedFunctions.EnableFramelock();
                traceResult = UnsortedFunctions.TraceLine(TargetVec, MeVec, 0x10);
                tickTime.Restart();
                for(int i = 0; i < 1; i++){
                        traceResult = UnsortedFunctions.TraceLine(TargetVec, MeVec, 0x10);
                }
                
                UnsortedFunctions.WriteToConsole("Trace Result: " + traceResult + " Trace Target Name: " + Target.Name+ " Time: " +tickTime.ElapsedMilliseconds);
                UnsortedFunctions.DisableFramelock();
            }
          
            
        }

        private void FollowPlayers()
        {
            ObjectManager.Read();
            
            var target = ObjectManager.Objects.Find(o => o.Type == 4 && o.GUID != ObjectManager.Objects[0].GUID);
            if (target.Name != null)
            {
                UnsortedFunctions.EnableFramelock();

                UnsortedFunctions.WriteToConsole(target.Name + " name  combat: " + target.IsInCombat);
                UnsortedFunctions.CGPlayer_C__ClickToMove(target.X, target.Y, target.Z, target.GUID, (int)Enums.ClickToMoveType.GoTo, 0);
                UnsortedFunctions.DisableFramelock();
            }
            else
            {
                UnsortedFunctions.WriteToConsole("no target :(");
            }
        }

        private void FrameLockCTM()
        {
            ObjectManager.Read();

            UnsortedFunctions.EnableFramelock();
            for (int i = 0; i < 100; i++)
            {
                UnsortedFunctions.CGPlayer_C__ClickToMove(10, 12, 12, ObjectManager.TargetGUID, 0x4, 0);
            }

            UnsortedFunctions.DisableFramelock();
        }

       
        private void ObjectmanagerToConsole()
        {
            ObjectManager.Read();
            Thread.Sleep(2000);
            foreach (Structs.ObjectInfo i in ObjectManager.Objects)
            {
                UnsortedFunctions.WriteToConsole(i.Name);
            }
        }

        public void Close()
        {
            // do nothing
        }

    }
}
