using Microsoft.Xna.Framework;
using SquintlysFurnitureMod.Content.Items.Blocks.Woods.Teak;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Tiles.Blocks.Woods.Teak;

public class TeakSlats : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileSolid[Type] = true;
        Main.tileBrick[Type] = true;
        Main.tileNoAttach[Type] = false;
        Main.tileBlockLight[Type] = true;

        AddMapEntry(new Color(77, 51, 0));

        RegisterItemDrop(ModContent.ItemType<TeakSlatsItem>());
    }
}