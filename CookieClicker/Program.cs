using Raylib_cs;
using System.Numerics;



Raylib.InitWindow(1200, 800, "CookieClicker");
//Raylib.SetWindowState(ConfigFlags.FLAG_FULLSCREEN_MODE);
Raylib.SetTargetFPS(30);

int screenWidth = Raylib.GetScreenWidth();
int screenHeight = Raylib.GetScreenHeight();
int mouseX = Raylib.GetMouseX();
int mouseY = Raylib.GetMouseY();
int CookiePwr = 1;
int Cookies = 0;
int Cost1 = 10;
//int CurrentCoPs = 0;
bool Buy100x = false;
bool Buy1x = true;
bool DrawHand = false;

Texture2D BtnImage = Raylib.LoadTexture("pixil-button-round.png");
Texture2D CookieImage = Raylib.LoadTexture("Pixel-cookie.png");
Texture2D Btn1xImage = Raylib.LoadTexture("pixil-button-1x.png");
Texture2D Btn100xImage = Raylib.LoadTexture("pixil-button-100x.png");
Texture2D HireBtnImage = Raylib.LoadTexture("pixil-button-hire.png");
Texture2D HandImage = Raylib.LoadTexture("pixil-hand.png");

Rectangle rect = new Rectangle(0, 50, CookieImage.width, CookieImage.height);
Rectangle btn = new Rectangle(1050, 700, BtnImage.width, BtnImage.height);

// Buy 1x, 100x, ALL buttons

Rectangle btn1x = new Rectangle(1050, 100, Btn1xImage.width, Btn1xImage.height);
Rectangle btn100x = new Rectangle(850, 100, Btn100xImage.width, Btn100xImage.height);
Rectangle hirebtn = new Rectangle(850, 700, HireBtnImage.width, HireBtnImage.height);
Rectangle hand = new Rectangle(CookieImage.width + 50, screenHeight / 2, HandImage.width, HandImage.height);




// Skapar lista för helpers
List<int> helpers = new List<int>();


while (Raylib.WindowShouldClose() == false)
{
    //LOGIK
    Vector2 mousePos = Raylib.GetMousePosition();

    //DEBUG
    // if (Raylib.CheckCollisionPointRec(mousePos, rect)) {
    // Raylib.DrawText("INSIDE", screenWidth/2, screenHeight/2, 2, Color.RED);

    // }

    //Raylib.DrawText($"mousePos: {mousePos}", mouseX, mouseY, 20, Color.DARKBLUE);
    Raylib.DrawText($"Current cookies: {Cookies}", 900, 600, 20, Color.DARKPURPLE);
    Raylib.DrawText($"Cookies per click: {CookiePwr}", 900, 580, 20, Color.DARKPURPLE);

    // Console.WriteLine(Raylib.GetFrameTime());
    // TRYCK PÅ KAKAN
    if (Raylib.CheckCollisionPointRec(mousePos, rect) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
    {
        Cookies = Cookies + CookiePwr;
    }

//Kontroller för ifall 1x knappen blir tryckt
    if (Raylib.CheckCollisionPointRec(mousePos, btn1x) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
    {
        Buy1x = true;
        Buy100x = false;
    }
    //Kontroller för ifall 100x knappen blir tryckt

    if (Raylib.CheckCollisionPointRec(mousePos, btn100x) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
    {
        Buy100x = true;
        Buy1x = false;
    }



// Buy100x modifiern, 
    if (Buy100x == true)
    {
        Cost1 = 1000;
        if (Raylib.CheckCollisionPointRec(mousePos, btn) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            if (Cookies >= Cost1)
            {
                CookiePwr += 100;
                Cookies -= Cost1;

            }

        }


    }


//Buy 1x Modifier
    if (Buy1x == true)
    {
        Cost1 = 10;
        if (Raylib.CheckCollisionPointRec(mousePos, btn) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
        {
            if (Cookies >= Cost1)
            {
                CookiePwr += 1;
                Cookies -= Cost1;

            }

        }


    }




    if (Raylib.CheckCollisionPointRec(mousePos, hirebtn) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
    {

        if (Cookies >= 100)
        {
            //Lägger till en helper i listan
            helpers.Add(1);
            //ritar en hand permanent på skärmen
            DrawHand = true;
            Cookies -= 100;
        }
    }


    foreach (int helper in helpers)
    {
        //debug
        Console.WriteLine("You have a helper");
        //Ger en kaka per frame
        Cookies += 1;
    }

//ritar en hand
    if (DrawHand == true)
    {
        Raylib.DrawRectangleRec(hand, Color.BLANK);
        Raylib.DrawTexture(HandImage, CookieImage.width + 50, screenHeight / 2, Color.WHITE);
       // Raylib.DrawText($"Helper is gathering: {CurrentCoPs} cookies per second!", 900, 620, 20, Color.DARKPURPLE);
    }




    // GRAFIK
    Raylib.BeginDrawing();


    Raylib.ClearBackground(Color.WHITE);
    //Raylib.DrawRectangleRec(character, Color.BLACK);
    Raylib.DrawTexture(CookieImage, 0, screenHeight / 2 - CookieImage.height / 2, Color.WHITE);
    Raylib.DrawTexture(BtnImage, 1050, 700, Color.WHITE);
    Raylib.DrawTexture(Btn100xImage, 850, 100, Color.WHITE);
    Raylib.DrawTexture(Btn1xImage, 1050, 100, Color.WHITE);
    Raylib.DrawTexture(HireBtnImage, 850, 700, Color.WHITE);

    Raylib.DrawRectangleRec(rect, Color.BLANK);
    Raylib.DrawRectangleRec(btn, Color.BLANK);
    Raylib.DrawRectangleRec(btn1x, Color.BLANK);
    Raylib.DrawRectangleRec(btn100x, Color.BLANK);
    Raylib.DrawRectangleRec(hirebtn, Color.BLANK);

    Raylib.DrawCircleV(mousePos, 10, new Color(255, 0, 0, 128));




    Raylib.EndDrawing();

}


//Raylib.UnloadTexture(CookieImage);

//Raylib.CloseWindow();

