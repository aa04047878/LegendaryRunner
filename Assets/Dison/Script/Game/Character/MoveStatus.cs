

public enum MoveStatus 
{
    None,
    FromLeftToMidMove,  //從左到中移動 
    FromMidToRightMove, //從中到右移動
    FromRightToMidMove, //從右到中移動
    FromMidToLeftMove,  //從中到左移動
    HitByCar,           //被車撞
    FallDown            //跌倒(也是掉下去的意思)
}
