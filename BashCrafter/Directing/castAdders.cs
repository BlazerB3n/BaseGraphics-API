using LocalLib.Casting;
using LocalLib.Types;
using LocalLib;

namespace BashCrafter
{
    
    public class castAdder
    {
        ItemAdder item = new ItemAdder();
        public void AddTree(Cast cast, Point position, string ActorKey)
        {
            int invSize = 1;
            Actor[] items = new Actor[invSize];
            items[0] = item.AddWood();

            Actor tree = new Actor(ActorKey);
            tree.AddAttribute(new AttributeBody(position, new Point(PROGRAM_SETTINGS.TREE_LENGTH, PROGRAM_SETTINGS.TREE_HEIGHT), 0));
            tree.AddAttribute(new AttributeColor(PROGRAM_SETTINGS.WHITE));
            tree.AddAttribute(new AttributeHealth(3));
            tree.AddAttribute(new AttributeClickable());
            tree.AddAttribute(new AttributeInventory(invSize, items));
            tree.AddAttribute(new AttributeTexture(TextureRegistry.TEXTURE_KEY_TREE, new Point(138, 155)));
            tree.AddAttribute(new AttributeAnimated(new Point(138, 155), 5));
            
            cast.AddActor("tree", tree);

        }

        public void Addrock(Cast cast, Point poisition, string ActorKey)
        {
            int invSize = 1;
            Actor[] items = new Actor[invSize];
            items[0] = item.AddStone();

            Actor rock = new Actor(ActorKey);
            rock.AddAttribute(new AttributeBody(poisition, new Point(PROGRAM_SETTINGS.ROCK_DIMENSIONS, PROGRAM_SETTINGS.ROCK_DIMENSIONS), 0));
            rock.AddAttribute(new AttributeColor(PROGRAM_SETTINGS.WHITE));
            rock.AddAttribute(new AttributeHealth(5));
            rock.AddAttribute(new AttributeClickable());
            rock.AddAttribute(new AttributeInventory(invSize, items));
            rock.AddAttribute(new AttributeTexture(TextureRegistry.TEXTURE_KEY_ROCK, new Point(128, 135)));
            rock.AddAttribute(new AttributeAnimated(new Point(128, 135), 5));

            cast.AddActor("rock", rock);
        }

        public void AddPlayer(Cast cast, Point position)
        {
            int invSize = 8;
            Actor[] items = new Actor[invSize];
            items[0] = item.AddStone();
            items[1] = item.AddWood();

            Actor actor = new Actor("player");
            actor.AddAttribute(new AttributeBody(position, new Point(64, 64), 120));
            actor.AddAttribute(new AttributeColor(new Color(255,255,255)));
            actor.AddAttribute(new AttributeInventory(invSize, items));
            actor.AddAttribute(new AttributeTexture(TextureRegistry.TEXTURE_KEY_Battler, new Point(64,64)));
            actor.AddAttribute(new AttributeAnimated(new Point(64,64), 9));
            
            // actor.AddAttribute(new AttributeEntity());
            actor.AddAttribute(new AttributeCameraTrack());
            
            cast.AddActor("player", actor);

        }
        public void AddBackground(Cast cast)
        {
            
        }
    }
}