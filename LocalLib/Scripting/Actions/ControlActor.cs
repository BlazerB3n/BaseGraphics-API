using LocalLib.Casting;
using LocalLib.Services;
using LocalLib.Types;

namespace LocalLib.Scripting.Actions
{
    /// <summary>
    /// A thing that is done in the game.
    /// </summary>
    public class ControlActorAction : Action
    {
        
        private KeyboardService keyboardService;

        public ControlActorAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <summary>
        /// Executes something that is important in the game. This method should be overriden by 
        /// derived classes.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        /// <param name="script">The script of actions.</param>
        public void Execute(Cast cast, Script script)
        {
            foreach (Actor item in cast.GetAllActors())
            {

                if (item.HasAttribute(AttributeKey.body))
                {
                    AttributeBody body = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
                    Point position = body.GetPosition();
                    Point velocity = new Point(0,0);

                    if (keyboardService.IsKeyDown(PROGRAM_SETTINGS.LEFT))
                    {
                        velocity = new Point(-7, 0);
                    }
                    else if (keyboardService.IsKeyDown(PROGRAM_SETTINGS.RIGHT))
                    {
                        velocity = new Point(7, 0);
                    }
                    else if (keyboardService.IsKeyDown("up"))
                    {
                        velocity = new Point(0, -7);
                    }
                    else if (keyboardService.IsKeyDown("down"))
                    {
                        velocity = new Point(0, 7);
                    }
                    else
                    {
                        velocity = new Point(0, 0);
                    }

                    body.SetVelocity(velocity);
                }
            }
        }
    }
}