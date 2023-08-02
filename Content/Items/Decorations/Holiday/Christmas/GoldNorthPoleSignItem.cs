//using Terraria;
//using Terraria.ID;
//using Terraria.GameContent.Creative;
//using Terraria.ModLoader;
//using SquintlysFurnitureMod.Content.Tiles.Decorations.Holiday.Christmas;

//namespace SquintlysFurnitureMod.Content.Items.Decorations.Holiday.Christmas;

//internal class GoldNorthPoleSignItem : ModItem
//{
//	public override void SetStaticDefaults()
//	{
//		DisplayName.SetDefault("Festive Sign");
//		CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
//	}

//	public override void SetDefaults()
//	{
//		Item.width = 16;
//		Item.height = 36;

//		Item.value = Item.buyPrice(copper:1);

//		Item.useStyle = ItemUseStyleID.Swing;
//		Item.useTurn = true;
//		Item.useAnimation = 15;
//		Item.useTime = 15;

//		Item.autoReuse = true;
//		Item.consumable = true;

//		Item.createTile = ModContent.TileType<GoldNorthPoleSign>();
//	}

//	public override void AddRecipes()
//	{
//		CreateRecipe()
//			.AddIngredient(ItemID.CandyCaneBlock, 4)
//            .AddTile(ModContent.TileType<FestiveWorktable>())
//            .Register();
//	}
//}