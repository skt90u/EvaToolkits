/**
 * @classDescription  弹出层构造函数
 * @type {Object}
 * @param {String | Object} 弹出层的id或者Dom对象 
 * @param {Object}  参数集合（包括modal, modalcolor, modalOpa, effect, pos, callback）
 */ 
function LightBox(boxId, option){
	this.setOption(option);
	var box = Kg.$I(boxId);
	var modalBox = Kg.$I("modal_layer");
	var iframe = Kg.$I("iframe_layer");
	var closeBtn = Kg.$C("close", box);
	var _this = this;
	var ori = window.resize;

	if(!modalBox){
		modalBox = document.createElement("div");
		modalBox.id = "modal_layer";
		document.body.appendChild(modalBox);
	}

	modalBox.style.cssText = "display:none; position:absolute; left:0; top:0; z-index:999; background-color:" + this.option.modalcolor;
	Kg.setOpacity(modalBox, this.option.modalOpa);

	if(!iframe){
		iframe = document.createElement("iframe");
		iframe.id = "iframe_layer";
		document.body.appendChild(iframe);
	}

	iframe.frameBorder = 0;
	iframe.style.cssText = "display:none; position:absolute; left:0; top:0; z-index:998;";
	Kg.setOpacity(iframe, 0);

	for(var i = 0; i < closeBtn.length; i++){
		Kg.addEvent(closeBtn[i], "click", Kg.bind(function(){
			this.close();
		}, this));
	}

	if(Kg.UA.Ie6){
		Kg.addEvent(window, "scroll", Kg.bind(function(){
			switch(this.option.pos){
				case "center":
					box.style.top = Kg.getBodySize().sT + (Kg.getBodySize().cH/2) + "px";
					box.style.left = Kg.getBodySize().sL + (Kg.getBodySize().cW/2) + "px";
					break;
				case "top":
					box.style.top = Kg.getBodySize().sT + "px";
					box.style.left = Kg.getBodySize().sL + "px";
					break;
				case "bottom":
					box.className = box.className;
					break;
			}
		}, this));
	}

	function resize(func){
		window.onresize = function(){
			ori && ori();
			func();
			window.setTimeout(function(){
				resize(func);
			},100);
			window.onresize = null;
		}
	};

	resize(function(){		
		var size = Kg.getBodySize();
		iframe.style.height = modalBox.style.height = size.cH + "px";
		iframe.style.width = modalBox.style.width = size.cW + "px";
		
		window.setTimeout(function(){
			var size = Kg.getBodySize();
			iframe.style.height = modalBox.style.height = Math.max(size.sH, size.cH) + "px";
			iframe.style.width = modalBox.style.width = Math.max(size.sW, size.cW) + "px";
		},0);

		if(Kg.UA.Ie6 && _this.option.pos === "center"){
			box.style.top = size.sT + (size.cH/2) + "px";
			box.style.left = size.sL + (size.cW/2) + "px";
		}
	});

	this.box = box;
	this.modalBox = modalBox;
	this.iframe = iframe;
};

LightBox.prototype.setOption = function(option){
	this.option = {
		modal:		true,		//是否打开黑幕层
		modalcolor:	"#000",		//黑幕层颜色
		modalOpa:	20,			//黑幕层透明度
		pos:	"center",		//弹出层出现的位置
		effect: "normal",		//显示效果
		fixed:	true,			//是否固定位置
		callback:	null,		//打开回调函数
		onClose:	null		//关闭回调函数
	};

	Kg.extend(this.option, option || {}, true);
};

LightBox.prototype.open = function(){
	var size = Kg.getBodySize();
	var box = this.box;
	var modalBox = this.modalBox;
	var iframe = this.iframe;
	
	if(this.option.modal){
		modalBox.style.display = "block";
		modalBox.style.height = Math.max(size.sH, size.cH) + "px";
		modalBox.style.width = Math.max(size.sW, size.cW) + "px";
	}

	iframe.style.display = "block";
	iframe.style.height = Math.max(size.sH, size.cH) + "px";
	iframe.style.width = Math.max(size.sW, size.cW) + "px";

	box.style.display = "block";
	box.style.zIndex = "1000";
	if(this.option.fixed)
		box.style.position = Kg.UA.Ie6?"absolute":"fixed";
	else
		box.style.position = "absolute";
	switch(this.option.pos){
		case "center" :
			switch(this.option.effect){
				case "normal":
					if(Kg.UA.Ie6){
						box.style.top = size.sT + (size.cH/2) + "px";
						box.style.left = size.sL + (size.cW/2) + "px";
						box.style.marginTop = -(box.offsetHeight/2) + "px";
						box.style.marginLeft = -(box.offsetWidth/2) + "px";
					} else {
						box.style.top = box.style.left = "50%";
						box.style.marginTop = -(box.offsetHeight/2) + "px";
						box.style.marginLeft = -(box.offsetWidth/2) + "px";
					}
					this.option.callback && this.option.callback(this);
					break;
				case "fade":
					var _this = this;
					var end = Math.floor(size.sT + (size.cH/2));
					var speed = (Kg.UA.Ie7 || Kg.UA.Ie8)?0.5:Kg.UA.Ie6?0.3:0.1;
					Kg.setOpacity(box, 0);
					if(Kg.UA.Ie6){
						Kg.slide(box, "top", (end - 50), end, speed, function(){
							_this.option.callback && _this.option.callback(_this);
						});
					} else {
						Kg.slide(box, "top", (end - 50), end, speed, function(o){
							o.style.left = o.style.top = "50%";
							_this.option.callback && _this.option.callback(_this);
						});
					}
					Kg.fadein(box, 1, 10);
					
					box.style.left = size.sL + (size.cW/2) + "px";
					box.style.marginTop = -(box.offsetHeight/2) + "px";
					box.style.marginLeft = -(box.offsetWidth/2) + "px";
					break;
				case "slide":
					var speed = (Kg.UA.Ie7 || Kg.UA.Ie8)?0.6:Kg.UA.Ie6?0.3:0.1;
					var width = parseInt(Kg.getStyle(box, "width"));
					var height = parseInt(Kg.getStyle(box, "height"));
					var _this = this;
					box.style.width = box.style.height = box.style.margin = box.style.padding =0;
					box.style.top = Kg.UA.Ie6?(size.sT + (size.cH/2) + "px"):"50%";
					box.style.left = Kg.UA.Ie6?(size.sL + (size.cW/2) + "px"):"50%";
					box.style.padding = 0;
					box.style.borderWidth = "1px";
					Kg.slide(box, "width", 0, width, speed, function(o){
						o.style.padding = box.style.borderWidth = "";
						Kg.slide(box, "height", 0, height, (speed), function(o){
							_this.option.callback && _this.option.callback(_this);
						}, function(o){
							o.style.marginTop = -(o.offsetHeight/2) + "px";
						})

					}, function(o){
						o.style.marginLeft = -(o.offsetWidth/2) + "px";
					}
					);
					break;
			}
			break;
		case "top" :
			if(Kg.UA.Ie6){
				box.style.top = size.sT + "px";
				box.style.left = size.sL + "px";
				box.style.marginTop = box.style.marginLeft = "";
			} else {
				box.style.top = box.style.left = "0";
				box.style.marginTop = box.style.marginLeft = "";
			}
			this.option.callback && this.option.callback(this);
			break;
		case "bottom" :
			box.style.top = box.style.left = "auto";
			box.style.bottom = 0;
			box.style.right = 0;
			box.style.marginTop = box.style.marginLeft = "";
			this.option.callback && this.option.callback(this);
	}
};

LightBox.prototype.close = function(){
	var size = Kg.getBodySize();
	var _this = this;
	var box = this.box;
	switch(this.option.effect){
		case "fade":
			if(this.option.pos === "center"){
				var end = Math.floor(size.sT + (size.cH/2));
				var speed = (Kg.UA.Ie7 || Kg.UA.Ie8)?0.5:Kg.UA.Ie6?0.3:0.1;
				box.style.position = "absolute";
				Kg.slide(box, "top", end, (end - 50), speed);
				Kg.fadeout(box, 1, 10, function(o){
					!Kg.UA.Ie6 && _this.option.fixed && (box.style.position = "fixed");
					o.style.display = _this.iframe.style.display = "none";
					_this.option.modal && (_this.modalBox.style.display = "none");
					Kg.setOpacity(o, 100);
				});
				this.option.onClose && this.option.onClose(this);
			} else {
				this.box.style.display = this.iframe.style.display = "none";
				this.option.modal && (this.modalBox.style.display = "none");
				this.option.onClose && this.option.onClose(this);
			}
			break;
		case "slide":
			if(this.option.pos === "center"){
				var speed = (Kg.UA.Ie7 || Kg.UA.Ie8)?0.6:Kg.UA.Ie6?0.3:0.1;
				var width = parseInt(Kg.getStyle(box, "width"));
				var height = parseInt(Kg.getStyle(box, "height"));
				Kg.slide(box, "height", height, 0, speed, function(o){
					o.style.padding = 0;
					o.style.borderWidth = "1px";
					Kg.slide(box, "width", width, 0, speed, function(o){
						o.style.padding = "";
						o.style.width = width + "px";
						o.style.height = height + "px";
						o.style.display = _this.iframe.style.display = "none";
						_this.option.modal && (_this.modalBox.style.display = "none");
					}, function(){
						o.style.marginLeft = -(o.offsetWidth/2) + "px";
					})

				}, function(o){
					o.style.marginTop = -(o.offsetHeight/2) + "px";
				});
				this.option.onClose && this.option.onClose(this);
			} else {
				this.box.style.display = this.iframe.style.display = "none";
				this.option.modal && (this.modalBox.style.display = "none");
				this.option.onClose && this.option.onClose(this);
			}
			break;	
		case "normal":
			this.box.style.display = this.iframe.style.display = "none";
			this.option.modal && (this.modalBox.style.display = "none");
			this.option.onClose && this.option.onClose(this);
			break;			
	}
};