using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

	private GameObject ItemLive;

	// Use this for initialization
	void Start () {
		// MainCameraのデータを取得
		this.ItemLive = GameObject.Find( "MainCamera" );

	}
	
	// Update is called once per frame
	void Update () {

		float cam, item;

		// カメラとアイテムのZ座標を取得
		cam = this.ItemLive.GetComponent<Transform>().position.z;
		item = this.GetComponent<Transform>().position.z;

		// カメラより後ろに配置されたら、消去
		if( item < cam ) {
			Destroy( this.gameObject );
		}
	}
}
