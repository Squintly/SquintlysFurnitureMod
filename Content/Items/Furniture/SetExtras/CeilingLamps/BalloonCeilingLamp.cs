using SquintlysFurnitureMod.Content.Tiles.Furniture.SetExtras.CeilingLamps;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace SquintlysFurnitureMod.Content.Items.Furniture.SetExtras.CeilingLamps;

internal class BalloonCeilingLamp : ModItem
{
    public override void SetStaticDefaults()
    {
        CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 14;
        Item.height = 24;

        Item.value = Item.buyPrice(gold: 2);

        Item.useStyle = (ItemUseStyleID.HoldUp);
        Item.useTurn = true;
        Item.useAnimation = 15;
        Item.useTime = 15;

        Item.autoReuse = true;
        Item.consumable = true;

        Item.maxStack = 9999;

        Item.createTile = ModContent.TileType<BalloonCeilingLampTile>();
    }

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ItemID.SillyBalloonGreen, 4)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches)
            .Register();

        CreateRecipe(1)
            .AddIngredient(ItemID.SillyBalloonPink, 4)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches)
            .Register();

        CreateRecipe(1)
            .AddIngredient(ItemID.SillyBalloonPurple, 4)
            .AddIngredient(ItemID.Torch)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}