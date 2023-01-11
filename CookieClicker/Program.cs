using Raylib_cs;
using System.Numerics;



Raylib.InitWindow(1920, 1080, "CookieClicker");
Raylib.SetWindowState(ConfigFlags.FLAG_FULLSCREEN_MODE);
Raylib.SetTargetFPS(30);

int screenWidth = Raylib.GetScreenWidth();
int screenHeight = Raylib.GetScreenHeight();
int mouseX = Raylib.GetMouseX();
int mouseY = Raylib.GetMouseY();
int CookiePwr = 1;
int Cookies = 0;
int Cost1 = 10;
Texture2D BtnImage = Raylib.LoadTexture("pixil-button-round.png");
Texture2D CookieImage = Raylib.LoadTexture("Pixel-cookie.png");
Rectangle rect = new Rectangle(0, 0, CookieImage.width, CookieImage.height);
Rectangle btn = new Rectangle(screenWidth - screenWidth / 10, screenHeight - screenHeight / 10, BtnImage.width, BtnImage.height);




while (Raylib.WindowShouldClose() == false)
{
    //LOGIK
    Vector2 mousePos = Raylib.GetMousePosition();

    //DEBUG
    // if (Raylib.CheckCollisionPointRec(mousePos, rect)) {
    // Raylib.DrawText("INSIDE", screenWidth/2, screenHeight/2, 2, Color.RED);

    // }

    Raylib.DrawText($"mousePos: {mousePos}", mouseX, mouseY, 20, Color.DARKBLUE);
    Raylib.DrawText($"Money: {Cookies}", 700, 700, 20, Color.DARKPURPLE);
    Raylib.DrawText($"Cookies per click: {CookiePwr}", 700, 730, 20, Color.DARKPURPLE);


    // TRYCK PÅ KAKAN
    if (Raylib.CheckCollisionPointRec(mousePos, rect) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
    {
        Cookies = Cookies + CookiePwr;
    }

    //KÖP POWER 
    if (Raylib.CheckCollisionPointRec(mousePos, btn) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
    {
        if (Cookies >= Cost1)
        {
            CookiePwr++;
            Cookies -= Cost1;

        }
        else
        {
            Raylib.DrawText("You do not have enough cookies", screenWidth - screenWidth / 10 - 180, screenHeight - screenHeight / 10 - 60, 20, Color.RED);
        }
    }











    // GRAFIK
    Raylib.BeginDrawing();


    Raylib.ClearBackground(Color.WHITE);
    //Raylib.DrawRectangleRec(character, Color.BLACK);
    Raylib.DrawTexture(CookieImage, 50, screenHeight / 2 - CookieImage.height / 2, Color.WHITE);
    Raylib.DrawTexture(BtnImage, screenWidth - screenWidth / 10, screenHeight - screenHeight / 10, Color.WHITE);
    Raylib.DrawRectangleRec(rect, Color.BLANK);
    Raylib.DrawRectangleRec(btn, Color.BLANK);

    Raylib.DrawCircleV(mousePos, 10, new Color(255, 0, 0, 128));




    Raylib.EndDrawing();
}

//Raylib.UnloadTexture(CookieImage);

//Raylib.CloseWindow();

