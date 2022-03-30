using System;
using System.Collections.Generic;
using System.IO;

using BashCrafter.clickActions;

using LocalLib.Casting;
using LocalLib.Scripting;
using LocalLib.Scripting.Actions;
using LocalLib.Services;
using LocalLib.Types;
using LocalLib.Screens;
using LocalLib;


namespace BashCrafter.Directing
{
    public class SceneManager
    {
        // public static VideoService VideoService = new RaylibVideoService(Constants.GAME_NAME,
        //     Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Constants.BLACK);
        public static AudioService AudioService = new RaylibAudioService();
        public static KeyboardService KeyboardService = new RaylibKeyboardService();
        public static VideoService VideoService = new RaylibVideoService(PROGRAM_SETTINGS.GAME_NAME,
                    PROGRAM_SETTINGS.SCREEN_WIDTH, PROGRAM_SETTINGS.SCREEN_HEIGHT, PROGRAM_SETTINGS.WHITE);

        public static MouseService MouseService = new RaylibMouseService();
        public static PhysicsService PhysicsService = new RaylibPhysicsService();

        public static castAdder addcast = new castAdder();
        public static MenuBuilder menuBuilder = new MenuBuilder();

        public List<Texture> TexturesList = new List<Texture>();

        // private Cast forground = new Cast();
        // private Cast midground = new Cast();
        
        // private Cast background = new Cast();
        

        private bool debug = true;
        private Random random = new Random(); 
        public SceneManager()
        {
            
        }

        public void InitializeTextures()
        {


            LocalLib.Types.Texture Icons = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_icons);
            LocalLib.Types.Texture Battler = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_Battler);
            LocalLib.Types.Texture Buttons = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_BUTTON);
            LocalLib.Types.Texture settings = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_settings);
            LocalLib.Types.Texture play = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_BUTTON_play);
            LocalLib.Types.Texture tree = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_TREE);
            LocalLib.Types.Texture rock = new LocalLib.Types.Texture(TextureRegistry.TEXTURE_PATH_ROCK);


            TexturesList.Add(settings);
            TexturesList.Add(Buttons);
            TexturesList.Add(Battler);
            TexturesList.Add(Icons);
            TexturesList.Add(play);
            TexturesList.Add(tree);
            TexturesList.Add(rock);
        }

        public void PrepareScene(string scene, Stage stage)
        {

            if (scene == PROGRAM_SETTINGS.NEW_GAME)
            {
                PrepareNewGame(stage);
            }
            else if (scene == "2")
            {
                PrepareNextGame(stage);
            }

            // else if (scene == PROGRAM_SETTINGS.NEXT_LEVEL)
            // {
            //     PrepareNextLevel(cast, script);
            // }
            // else if (scene == PROGRAM_SETTINGS.TRY_AGAIN)
            // {
            //     PrepareTryAgain(cast, script);
            // }
            // else if (scene == PROGRAM_SETTINGS.IN_PLAY)
            // {
            //     PrepareInPlay(cast, script);
            // }
            // else if (scene == PROGRAM_SETTINGS.GAME_OVER)
            // {
            //     PrepareGameOver(cast, script);
            // }
        }

        private void PrepareNewGame(Stage stage)
        {
            // AddStats(cast);
            // AddLevel(cast);
            // AddScore(cast);
            // AddLives(cast);
            // AddBall(cast);
            // AddBricks(cast);
            // AddRacket(cast);
            // AddPlayer(cast);
            // AddDialog(cast, PROGRAM_SETTINGS.ENTER_TO_START); 

            Actor player = null;
            
            if (stage.midground.GetFirstActor("player") != null)
            {
                player = stage.midground.GetFirstActor("player");

            }

            //stage.ClearCast();

            // background
            Actor background = new Actor("background");
            background.AddAttribute(new AttributeBody(new Point(0,0), new Point(PROGRAM_SETTINGS.MAP_X,PROGRAM_SETTINGS.MAP_Y), 0));
            background.AddAttribute(new AttributeColor(PROGRAM_SETTINGS.GREEN));

            stage.background.AddActor("background", background);

            // midground
            if (player == null)
            {
                addcast.AddPlayer(stage.midground, new Point(0,0));
            }else
            {
                stage.midground.AddActor("player", player);
            }

            for (int i = 0; i < 5; i++)
            {
            addcast.Addrock(stage.midground, new Point(random.Next(PROGRAM_SETTINGS.MAP_X - PROGRAM_SETTINGS.ROCK_DIMENSIONS), random.Next(PROGRAM_SETTINGS.MAP_Y - PROGRAM_SETTINGS.ROCK_DIMENSIONS)),"Rock " + i);
            addcast.AddTree(stage.midground, new Point(random.Next(PROGRAM_SETTINGS.MAP_X - PROGRAM_SETTINGS.TREE_LENGTH), random.Next(PROGRAM_SETTINGS.MAP_Y - PROGRAM_SETTINGS.TREE_HEIGHT)),"Tree " + i);
            }

            // forground
            menuBuilder.AddButton(stage.forground, new Point(100,100), new Point(200,50));


            // setup Actions
            // stage.ClearActions();


            stage.ClearActions();
            MouseMenuAction mouseMenu = new MouseMenuAction(MouseService, new InventoryMenu());

            stage.addActionToScript("control", new ControlActorAction(KeyboardService, VideoService));
            stage.addActionToScript("COLISHION", new CollideActorsAction(PhysicsService, AudioService, VideoService));
            stage.addActionToScript("COLISHION", new MouseInteracAction(MouseService));
            stage.addActionToScript("COLISHION", mouseMenu);
            // stage.addActionToScript("COLISHION",  new MouseObjectAction(MouseService));

            // stage.addActionToScript("menu", new TestClick(mouseMenu, new testClicker_attribute()));
            stage.addActionToScript("move", new MoveActor(VideoService));
            stage.addActionToScript("camera", new MoveCameraAction(VideoService));
            
            stage.addActionToScript("startDrawing", new StartDrawing(VideoService));
            stage.addActionToScript("drawforground", new DrawActorsBackground(VideoService));
            stage.addActionToScript("drawMidground", new DrawActorTexture(VideoService));
            stage.addActionToScript("end2dDraw", new End2dCamera(VideoService));
            stage.addActionToScript("drawBackground", new DrawActorsForground(VideoService));
            stage.addActionToScript("endDrawing", new EndDrawing(VideoService));
            stage.addActionToScript("changesen", new ChangeSceneAction(KeyboardService, PROGRAM_SETTINGS.NEW_GAME));

            // stage.addActionToScript("control", new ControlActorAction(KeyboardService));
            // stage.addActionToScript("COLISHION", new CollideActorsAction(PhysicsService, AudioService, VideoService));
            // stage.addActionToScript("COLISHION", new MouseInteracAction(MouseService));
            // stage.addActionToScript("move", new MoveActor(VideoService));
            // stage.addActionToScript("camera", new MoveCameraAction(VideoService));
            
            // stage.addActionToScript("startDrawing", new StartDrawing(VideoService));
            // stage.addActionToScript("draw", new DrawActorTexture(VideoService));
            // stage.addActionToScript("endDrawing", new EndDrawing(VideoService));
            // stage.addActionToScript("changesen", new ChangeSceneAction(KeyboardService, "2"));
        }


        private void PrepareNextGame(Stage stage)
        {
            // AddStats(cast);
            // AddLevel(cast);
            // AddScore(cast);
            // AddLives(cast);
            // AddBall(cast);
            // AddBricks(cast);
            // AddRacket(cast);
            // AddPlayer(cast);
            // AddDialog(cast, PROGRAM_SETTINGS.ENTER_TO_START); 
            Actor player = stage.midground.GetFirstActor("player");
stage.ClearCast();

            // background
            Actor backdrop = new Actor("background");
            backdrop.AddAttribute(new AttributeBody(new Point(0,0), new Point(10000,10000), 0));
            backdrop.AddAttribute(new AttributeColor(PROGRAM_SETTINGS.GREEN));

            // stage.background.AddActor("background", backdrop);

            // midground
            
            // addcast.AddPlayer(stage.midground);
            stage.midground.AddActor("player", player);

            // addcast.Addrock(stage.midground);



            

            // forground


            // setup Actions
            stage.ClearActions();

            stage.addActionToScript("control", new ControlActorAction(KeyboardService, VideoService));
            stage.addActionToScript("COLISHION", new CollideActorsAction(PhysicsService, AudioService, VideoService));
            stage.addActionToScript("COLISHION", new MouseInteracAction(MouseService));
            stage.addActionToScript("move", new MoveActor(VideoService));
            stage.addActionToScript("camera", new MoveCameraAction(VideoService));
            
            stage.addActionToScript("startDrawing", new StartDrawing(VideoService));
            stage.addActionToScript("draw", new DrawActorsBackground(VideoService));
            stage.addActionToScript("draw", new DrawActorTexture(VideoService));
            stage.addActionToScript("end2dDraw", new End2dCamera(VideoService));
            stage.addActionToScript("draw", new DrawActorsForground(VideoService));
            stage.addActionToScript("endDrawing", new EndDrawing(VideoService));
            stage.addActionToScript("changesen", new ChangeSceneAction(KeyboardService, PROGRAM_SETTINGS.NEW_GAME));
        }


        private void PrepareInventory(Stage menu)
        {
            // addcast.AddBackground(menu.background, new Point(512,512), new Color(25,70,120));
            
            menu.addActionToScript("COLISHION", new MouseInteracAction(MouseService));
            
            // menu.addActionToScript("camera", new MoveCameraAction(VideoService));

            // menu.addActionToScript("startDrawing", new StartDrawing(VideoService));
            menu.addActionToScript("draw", new DrawActorTexture(VideoService));
            menu.addActionToScript("endDrawing", new EndDrawing(VideoService));
            // menu.addActionToScript("changesen", new ChangeSceneAction(KeyboardService, PROGRAM_SETTINGS.NEW_GAME));

            // menu.background.AddActor("background", );
        }
        // -----------------------------------------------------------------------------------------
        // casting methods
        // -----------------------------------------------------------------------------------------




        private List<List<string>> LoadLevel(string filename)
        {
            List<List<string>> data = new List<List<string>>();
            using(StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    List<string> columns = new List<string>(row.Split(',', StringSplitOptions.TrimEntries));
                    data.Add(columns);
                }
            }
            return data;
        }

        // -----------------------------------------------------------------------------------------
        // scriptig methods
        // -----------------------------------------------------------------------------------------

        // private void AddInitActions(Script script)
        // {
        //     script.AddAction(Constants.INITIALIZE, new InitializeDevicesAction(AudioService, 
        //         VideoService));
        // }

        // private void AddLoadActions(Script script)
        // {
        //     script.AddAction(Constants.LOAD, new LoadAssetsAction(AudioService, VideoService));
        // }

        private void AddOutputActions(Stage stage)
        {
            // stage.addActionToScript(Constants.OUTPUT, new StartDrawingAction(VideoService));
            // stage.addActionToScript(Constants.OUTPUT, new DrawHudAction(VideoService));
            // stage.addActionToScript(Constants.OUTPUT, new DrawBallAction(VideoService));
            // stage.addActionToScript(Constants.OUTPUT, new DrawBricksAction(VideoService));
            // stage.addActionToScript(Constants.OUTPUT, new DrawRacketAction(VideoService));
            // stage.addActionToScript(Constants.OUTPUT, new DrawDialogAction(VideoService));
            // stage.addActionToScript(Constants.OUTPUT, new DrawPlayerAction(VideoService));
            // stage.addActionToScript(Constants.OUTPUT, new EndDrawingAction(VideoService));
        }

        private void AddUnloadActions(Stage stage)
        {
            // stage.addActionToScript(Constants.UNLOAD, new UnloadAssetsAction(AudioService, VideoService));
        }

        private void AddReleaseActions(Stage stage)
        {
            // stage.addActionToScript(Constants.RELEASE, new ReleaseDevicesAction(AudioService, 
            //     VideoService));
        }

        private void AddUpdateActions(Stage stage)
        {
            // stage.addActionToScript(Constants.UPDATE, new MoveBallAction());
            // stage.addActionToScript(Constants.UPDATE, new MoveRacketAction());
            // stage.addActionToScript(Constants.UPDATE, new MovePlayerAction());
            // stage.addActionToScript(Constants.UPDATE, new CollideBordersAction(PhysicsService, AudioService));
            // stage.addActionToScript(Constants.UPDATE, new CollideBrickAction(PhysicsService, AudioService));
            // stage.addActionToScript(Constants.UPDATE, new CollideRacketAction(PhysicsService, AudioService));
            // stage.addActionToScript(Constants.UPDATE, new CheckOverAction());     
        }
    }
}