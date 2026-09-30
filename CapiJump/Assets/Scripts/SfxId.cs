/// <summary>
/// Nomes dos efeitos sonoros usados no AudioManager.
/// Use estas constantes em vez de strings soltas ("Jump", "Coin", etc.)
/// pra evitar erros de digitação — se digitar errado, o compilador acusa.
///
/// IMPORTANTE: os valores aqui precisam bater exatamente com o campo
/// "Name" de cada som configurado no Inspector do AudioManager.
/// </summary>
public static class SfxId
{
    public const string Jump = "Jump";
    public const string Coin = "Coin";
    public const string PowerUp = "PowerUp";
    public const string GameOver = "GameOver";
    public const string Win = "Win";
    public const string UIClick = "UIClick";
}