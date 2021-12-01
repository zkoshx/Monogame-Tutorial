using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Learning_Monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D targetSprite;
        Texture2D crosshairSprite;
        Texture2D bgSprite;
        SpriteFont gameFont;

        Vector2 targetPos = new Vector2(300, 300);
        const int rad = 45;

        MouseState mState;
        bool mReleased = true;
        int score = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            targetSprite = Content.Load<Texture2D>("target");
            crosshairSprite = Content.Load<Texture2D>("crosshairs");
            bgSprite = Content.Load<Texture2D>("sky");
            gameFont = Content.Load<SpriteFont>("galleryFont");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mState = Mouse.GetState();

            if (mState.LeftButton == ButtonState.Pressed && mReleased == true)
            {
                float mouseTargetDist = Vector2.Distance(targetPos, mState.Position.ToVector2());
                if (mouseTargetDist < rad)
                {
                    score++;
                    Random rnd = new Random();
                }
                mReleased = false;
            }

            if (mState.LeftButton == ButtonState.Released)
            {
                mReleased = true;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _spriteBatch.Begin();
            _spriteBatch.Draw(bgSprite, new Vector2(0, 0), Color.White);
            _spriteBatch.DrawString(gameFont, score.ToString(), new Vector2(100,0), Color.Blue);
            _spriteBatch.Draw(targetSprite, new Vector2(targetPos.X - rad, targetPos.Y - rad), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
