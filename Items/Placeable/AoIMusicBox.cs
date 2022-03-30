using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace EternalMusic.Items.Placeable
{
    public class AoIMusicBox : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Music Box (Ark of Imperious)");
            if (!ModContent.GetInstance<EternalMusicConfig>().originalMusic)
                Tooltip.SetDefault("JakeTEM - Imperious Strike");
            else
                Tooltip.SetDefault("JakeTEM - Blade of Brutality");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 30;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = ModContent.TileType<Tiles.AoIMusicBox>();
            item.rare = ItemRarityID.LightRed;
            item.value = Item.sellPrice(silver: 10);
            item.accessory = true;
        }

    }
}
