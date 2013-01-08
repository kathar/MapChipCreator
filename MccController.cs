using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ka;
using ka.WinForm;

namespace MapChipCreator
{
	public class MccController : KaController
	{
		protected override void init()
		{
			base.init();

			bindChips();
		}

		// チップにイベントを設定
		private void bindChips()
		{
			var m = model as MccModel;
			var v = view as MccView;

			var bgImgMgr = new KaBmpDatMgr( m.ChipEmptyImg as Bitmap );
			var overImgMgr = new KaBmpDatMgr( m.ChipOverImg as Bitmap );

			Bitmap dropImg = null;
			
			var chips = v.chips;

			foreach ( var chip in chips )
			{
				// マウスオーバーイベント
				chip.MouseEnter += ( s, e ) =>
				{
					chip.Image = overImgMgr.magnify( MccView.ChipSize / m.ChipOverImg.Width );
				};
				chip.MouseLeave += ( s, e ) =>
				{
					chip.Image = null;
				};

				// D&D イベント
				/// ドラッグオーバー
				chip.DragEnter += ( s, e ) =>
				{
					var fileNames = e.Data.GetData( DataFormats.FileDrop ) as string[];

					// エラー処理
					/// null の場合
					if ( !fileNames.KaIs() ) return;
					/// ドラッグ対象が1つ以外
					if ( fileNames.Length != 1 ) return;
					/// ドラッグ対象が画像以外
					try { dropImg = new Bitmap( fileNames[ 0 ] ); }
					catch( ArgumentException ) { return; }

					// ドラッグ対象が1つで、画像ファイルの場合
					e.Effect = DragDropEffects.All;
					chip.Image = overImgMgr.magnify( MccView.ChipSize / m.ChipOverImg.Width );
				};
				/// ドラッグリーブ
				chip.DragLeave += ( s, e ) =>
				{
					chip.Image = null;
				};
				/// ドロップ
				chip.DragDrop += ( s, e ) =>
				{
					// サイズチェック
					/// チップサイズ以下のサイズなら OK
					if( dropImg.Width > chip.Width
						|| dropImg.Height > chip.Height )
					{
						return;
					}
					/// 縦 : 横 = 1 : 1 のみを許可
					if ( dropImg.Width != dropImg.Height )
					{
						return;
					}

					var dropImgMgr = new KaBmpDatMgr( dropImg );
					chip.BackgroundImage = dropImgMgr.magnify( MccView.ChipSize / dropImg.Width );
				};
				
				// クリックイベント
				chip.Click += ( s, e ) =>
				{
					var mgr = new KaBmpDatMgr( chip.BackgroundImage as Bitmap );
					v.detailChip.Image = mgr.magnify( MccView.DetailSizeRate );
				};
			}
		}
	}
}
