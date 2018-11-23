// Copyright 2018 The Chromium Authors. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

// DEV: Tells the Chrome what listeners need to run in the background of the applications.

"use strict";

chrome.runtime.onInstalled.addListener(function() {
  chrome.storage.sync.set({ color: "#3aa757" }, function() {
    console.log("The color is green.");
  });

  // DEV: For "page_actions" in the "manifest.json" you need declarative content enabled
  /* 
  chrome.declarativeContent.onPageChanged.removeRules(undefined, function() {
    chrome.declarativeContent.onPageChanged.addRules([
      {
        conditions: [
          new chrome.declarativeContent.PageStateMatcher({
            pageUrl: { hostContains: ".developer.chrome.com" }
          }),
          new chrome.declarativeContent.PageStateMatcher({
            pageUrl: { hostContains: ".amazon.com" }
          })
        ],
        actions: [new chrome.declarativeContent.ShowPageAction()]
      }
    ]);
  });
  */
});
