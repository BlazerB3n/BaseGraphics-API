using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;
using LocalLib.Services;
using LocalLib.Casting;
using LocalLib.Scripting;
using LocalLib.Screens;
using LocalLib;


namespace BashCrafter.Directing
{

    public class newDirector : ActionCallback
    {
        // private InputService inputService = null;
        private VideoService videoService = null;

        // Stages stage = Stages.TITLE;
        
        // private Dictionary<Stages, IStage> stages = null;
            // SET UP THE stages
        // Dictionary<Stages, IStage> stagelist = new Dictionary<Stages, IStage>();
        // Dictionary<string, MenuService> menus = null;
        // List<IMenu> menus = null;

        Stage stageMain = new Stage();
        Cast Menu = new Cast();

        SceneManager sceneManager = null;
        
        Script script;

        LocalLib.Scripting.Actions.SetupVideo SetupVideo = null;
        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="inputService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public newDirector(
            // InputService inputService,
             VideoService videoService
        )
        {
            // this.inputService = inputService;
            this.videoService = videoService;
            this.script = new Script();
            this.sceneManager = new SceneManager();
        }

        
        /// </inheritdoc>
        public void OnNext(string scene)
        {
            sceneManager.PrepareScene(scene, stageMain);
        }

        public void GameLoop()
        {
            // Stages TMP = Stages.TITLE;

            // videoService.Initialize();
            sceneManager.InitializeTextures();
            SetupVideo = new LocalLib.Scripting.Actions.SetupVideo(videoService, sceneManager.TexturesList);
            SetupVideo.Execute();
            

            sceneManager.PrepareScene(PROGRAM_SETTINGS.NEW_GAME, stageMain);
            // SetupStages(inputService, videoService);

            while (videoService.IsWindowOpen())
            {
                
                

                // stageMain.GetInputs(cast, script, "control");
                // stageMain.GetInputs(cast, script, "COLISHION");
                // stageMain.GetInputs(cast, script, "move");
                // stageMain.GetInputs(cast, script, "camera");
                // ExecuteActions(stageMain);
                // ExecuteActions(stageMain);
                // ExecuteActions(stageMain);
                // ExecuteActions(stageMain);
                // videoService.ClearBuffer(true);
                
                // stageMain.GetInputs(cast, script, "draw");
                ExecuteActions(stageMain);

                // ExecuteActions("control");
                // ExecuteActions("move");
                // ExecuteActions("draw");
                // stagelist[stage].GetInputs();
                // TMP = stagelist[stage].DoUpdates();
                // List<Actor> actors = stagelist[stage].DoOutputs();

                // videoService.DrawActors(actors);
                // videoService.End2dMap();

                // videoService.FlushBuffer();
                // stage = TMP;
            }
            videoService.Release();
        }

        private void ExecuteActions(Stage stage)
        {
            stage.GetInputs(this);
            // List<Scripting.Action> actions = script.GetActions(group);
            // foreach(Scripting.Action action in actions)
            // {
            //     action.Execute(cast, script);
            // }
        }

        // private void SetupStages(InputService inputService, VideoService videoService 
        //                                 )
        // {
        //     // GameStage gameStage = new GameStage(keyboardService, videoService);
        //     // TitleStage titleStage = new TitleStage(keyboardService, videoService, menu);
        //     // TitleStage welcomeStage = new TitleStage(inputService, videoService);
        //     // GameStage gameStage = new GameStage(inputService, videoService);
            
        //     // stagelist.Add(Stages.TITLE, welcomeStage);
        //     // stagelist.Add(Stages.GAME, gameStage);
        //     // stagelist.Add(GAME, gameStage);
        // }
    }
}
