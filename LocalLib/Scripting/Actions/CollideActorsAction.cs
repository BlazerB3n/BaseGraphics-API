using LocalLib.Casting;
using LocalLib.Services;
using LocalLib.Types;
using System;

namespace LocalLib.Scripting
{
    public class CollideActorsAction : Action
    {
        private AudioService audioService;
        private PhysicsService physicsService;
        private VideoService videoService;
        
        public CollideActorsAction(PhysicsService physicsService, AudioService audioService, VideoService videoService)
        {
            this.physicsService = physicsService;
            this.audioService = audioService;
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script)
        {
            // Ball ball = (Ball)cast.GetFirstActor(Constants.BALL_GROUP);
            // Racket racket = (Racket)cast.GetFirstActor(Constants.RACKET_GROUP);
            // Body ballBody = ball.GetBody();
            // Body racketBody = racket.GetBody();

            Actor player = cast.GetFirstActor("player");
            AttributeBody playBody = (AttributeBody)player.GetActorAttribute(AttributeKey.body);
            Point playerPos = playBody.GetPosition();
            int playerY = playerPos.GetY();
            int playerX = playerPos.GetX();
            foreach (Actor item in cast.GetAllActors())
            {

                AttributeBody itemBody = (AttributeBody) item.GetActorAttribute(AttributeKey.body);
            Point itemPos = itemBody.GetPosition();
            int itemX = itemPos.GetX();
            int itmeY = itemPos.GetY();
            
            // System.Console.WriteLine(videoService == null);

            if (
            itemX <= playerX &&
            itemX + itemBody.GetSize().GetX() >=  playerX &&
            itmeY >= playerY &&
            itmeY < playerY + playBody.GetSpeed() * videoService.GetDeltaTime())
        {
            // hitObstacle = 1;
            playBody.SetSpeed(0.0f);
            playBody.SetPosition(new Point(playerPos.GetX(), itemPos.GetY()));
                    Console.WriteLine($"player collided {cast.GetAllActors().IndexOf(item)}");
        }
                // System.Console.WriteLine($"player colided with  {cast.GetAllActors().IndexOf(item)}");
            //     if (physicsService.HasCollided(playBody, itemBody) && cast.GetFirstActor("player") != item )
            //     {
            //         // cast.GetDictionary().
            //         // Console.WriteLine($"player collided {cast.GetAllActors().IndexOf(item)}");

            //         Types.Point point = playBody.GetVelocity();


            //         // playBody.SetVelocity(new Types.Point(-(point.GetX()), -(point.GetY())));


            // playBody.SetSpeed(100.0f);
            // playBody.SetPosition(new Point( playerPos.GetX(), playerPos.GetY()));

            //         // playBody.SetVelocity(new Types.Point(-(point.GetX()*2), -(point.GetY()*2)));
            //         // playBody.SetVelocity(new Types.Point(0, 0));
            //         // ball.BounceY();
            //         // Sound sound = new Sound(Constants.BOUNCE_SOUND);
            //         // audioService.PlaySound(sound);
            //     }
            //     // Racket player = (Racket)cast.GetFirstActor(Constants.PLAYER_GROUP);
            //     // Body playerBody = player.GetBody();

            //     // if (physicsService.HasCollided(playerBody, ballBody))
            //     // {
                    
            //     //     ball.BounceY();
            //     //     Sound sound = new Sound(Constants.BOUNCE_SOUND);
            //     //     audioService.PlaySound(sound);
            //     // }
            }
        }
    }
}