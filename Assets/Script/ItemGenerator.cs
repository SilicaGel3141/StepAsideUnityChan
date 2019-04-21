using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

	public GameObject carPrefab;
	public GameObject coinPrefab;
	public GameObject conePrefab;
	public GameObject unityChan;

	private int startPos = -160;
	private int goalPos = 120;
	private float posRange = 3.4f;

	// 次回アイテム生成する座標
	private float geneNextPos = 0.0f;

	// アイテム生成する間隔
	private float geneStep = 15.0f;

	// どのくらい先にアイテムを配置するか
	// 40～50の間だが
	// 割と生成しているのが見えたので課題指定範囲のMAX値でやる
	private int geneDistance = 50;

	// Use this for initialization
	void Start() {

		this.unityChan = GameObject.Find( "unitychan" );

		// 考え方
		// unityちゃんのZ座標を元に、15mおきにItem生成関数を呼び出す
		geneNextPos = this.unityChan.GetComponent<Transform>().position.z;

	}

	// Update is called once per frame
	void Update() {

		float unityZPos;
		int geneZ;

		// 現在の座標を取得
		unityZPos = this.unityChan.GetComponent<Transform>().position.z;

		// 配置条件の座標を超えたらif文の中を実行
		if( unityZPos > geneNextPos ) {
			// 配置するZ座標を指定
			geneZ = (int)unityZPos + geneDistance;
			// ゴールより手前の時に配置する
			if( geneZ < goalPos ) {
				ItemGenerate( geneZ );
				geneNextPos += geneStep;
			}
		}
	}

	private void ItemGenerate( int z ) {

		// 元のLessonで作ったアイテム生成処理を若干引用
		// 生成先のZ座標の変数だけ変更
		int num = Random.Range( 1, 11 );
		if( num <= 2 ) {
			for( float j = -1; j <= 1; j += 0.4f ) {
				GameObject cone = Instantiate( conePrefab ) as GameObject;
				cone.transform.position = new Vector3( 4 * j, cone.transform.position.y, z );
			}
		} else {
			for( int j = -1; j <= 1; j++ ) {
				int item = Random.Range( 1, 11 );
				int offsetZ = Random.Range( -5, 6 );
				if( 1 <= item && item <= 6 ) {
					GameObject coin = Instantiate( coinPrefab ) as GameObject;
					coin.transform.position = new Vector3( posRange * j, coin.transform.position.y, z + offsetZ );
				} else if( 7 <= item && item <= 9 ) {
					GameObject car = Instantiate( carPrefab ) as GameObject;
					car.transform.position = new Vector3( posRange * j, car.transform.position.y, z + offsetZ );
				}
			}
		}

	}
}
