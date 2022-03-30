using LocalLib.Types;


namespace LocalLib
{
    public struct AttributeKey
    {
        public static string text = "text";
        public static string body = "body";
        public static string color = "color";
        public static string texture = "texture";
        public static string clickable = "clickable";
        public static string animated = "animated";

        public static string TrackAble = "trackable";
        public static string Stage_Position = "stage_position";
        public static string health = "health";


        // menu atributes
        public static string testClicker_ = "testclick";
        public static string Inventory = "Inventory";
        public static string InventoryMenu = "InventoryMenu";
    }
    public struct ItemAttributeKey
    {
        public static string Stack = "stack";
    }
    //     public class TextureKey
    // {
    //     public static string body = "body";
    //     public static string color = "color";
    //     public static string texture = "texture";
    // }
    
    public struct PROGRAM_SETTINGS
    {
        // ----------------------------------------------------------------------------------------- 
        // GENERAL GAME CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // GAME
        public static string GAME_NAME = "Bashcrafter";
        public static int FRAME_RATE = 60;

        // SCREEN
        public static int SCREEN_WIDTH = 1040;
        public static int SCREEN_HEIGHT = 680;
        public static int CENTER_X = SCREEN_WIDTH / 2;
        public static int CENTER_Y = SCREEN_HEIGHT / 2;
        public static int MAP_X = 1000;
        public static int MAP_Y = 1000;

        public static int GRID_X = 64;
        public static int GRID_Y = 64;

        // FIELD
        public static int FIELD_TOP = 60;
        public static int FIELD_BOTTOM = SCREEN_HEIGHT;
        public static int FIELD_LEFT = 0;
        public static int FIELD_RIGHT = SCREEN_WIDTH;

        // FONT
        public static string FONT_FILE = "Assets/Fonts/zorque.otf";
        public static int FONT_SIZE = 32;

        // SOUND
        public static string BOUNCE_SOUND = "Assets/Sounds/boing.wav";
        public static string WELCOME_SOUND = "Assets/Sounds/start.wav";
        public static string OVER_SOUND = "Assets/Sounds/over.wav";

        // TEXT
        public static int ALIGN_LEFT = 0;
        public static int ALIGN_CENTER = 1;
        public static int ALIGN_RIGHT = 2;


        // COLORS
        public static Color BLACK = new Color(0, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color PURPLE = new Color(255, 0, 255);
        public static Color GREEN = new Color(0, 255, 0);

        // KEYS
        public static string LEFT = "left";
        public static string RIGHT = "right";
        public static string UP = "up";
        public static string DOWN = "down";
        public static string SPACE = "space";
        public static string ENTER = "enter";
        public static string PAUSE = "p";



        // SCENES
        public static string MAIN_MENU = "main_menu";
        public static string NEW_GAME = "new_game";
        public static string TRY_AGAIN = "try_again";
        public static string NEXT_LEVEL = "next_level";
        public static string IN_PLAY = "in_play";
        public static string GAME_OVER = "game_over";

        // LEVELS
        public static string LEVEL_FILE = "Assets/Data/level-{0:000}.txt";
        public static int BASE_LEVELS = 5;

        // ACTORS
        public static int TREE_HEIGHT = 128;
        public static int TREE_LENGTH = 64;
        public static int ROCK_DIMENSIONS = 50;
        

    public static string DATA_PATH = "Data/messages.txt";
    public static string TEXTURE_PATH_icons = "Data/Textures/icons_vx.png";
    public static string TEXTURE_PATH_Battler = "Data/Textures/battler_1_1.png";
    public static string TEXTURE_PATH_BUTTONS = "Data/Textures/Button_play.png";
    }

}