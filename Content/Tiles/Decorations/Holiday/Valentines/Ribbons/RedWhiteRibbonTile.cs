using SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Valentines.Ribbons;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Valentines.Ribbons;

public class RedWhiteRibbonTile : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = false;
        Main.tileBrick[Type] = false;
        Main.tileNoAttach[Type] = false;
        Main.tileBlockLight[Type] = false;

        TileObjectData.newTile.CopyFrom(TileObjectData.StyleSwitch);
        TileObjectData.addTile(Type);

        RegisterItemDrop(ModContent.ItemType<RedWhiteRibbons>());
    }
}