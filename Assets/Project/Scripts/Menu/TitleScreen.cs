﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class TitleScreen : MenuScreen {
    public int selectedItem = 0;
    public Text startGameText;
    public Text highScoreText;
    public Text exitGameText;

    private bool canMoveCursor = true;

    private void Start() {
        HighlightMenuItem(selectedItem);
    }

    private void Update() {
        float vAxis = GetAnyAxis("Vertical");
        if (vAxis < -0.2 && canMoveCursor) {
            selectedItem++;
            if (selectedItem >= 3) {
                selectedItem = 0;
            }
            HighlightMenuItem(selectedItem);
            canMoveCursor = false;
        }
        else if (vAxis > 0.2 && canMoveCursor) {
            selectedItem--;
            if (selectedItem < 0) {
                selectedItem = 2;
            }
            HighlightMenuItem(selectedItem);
            canMoveCursor = false;
        }
        else if (vAxis < 0.2 && vAxis > -0.2) {
            canMoveCursor = true;
        }

        if (GetAnyAccept()) {
            SelectMenuItem(selectedItem);
        }
    }

    public void HighlightMenuItem(int item) {
        SetAllMenuItemsInactive();
        switch(item) {
            case 0:
                startGameText.color = new Color(0.6f, 0.35f, 0f);
                break;
            case 1:
                highScoreText.color = new Color(0.6f, 0.35f, 0f);
                break;
            case 2:
                exitGameText.color = new Color(0.6f, 0.35f, 0f);
                break;
        }
        selectedItem = item;
    }

    private void SetAllMenuItemsInactive() {
        startGameText.color = new Color(0f, 0f, 0f);
        highScoreText.color = new Color(0f, 0f, 0f);
        exitGameText.color = new Color(0f, 0f, 0f);
    }

    public void SelectMenuItem(int item) {
        MenuController c = this.GetComponentInParent<MenuController>();
        switch (item) {
            case 0:
                c.SetScreen(1);
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
}
