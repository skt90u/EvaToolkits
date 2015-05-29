(function(){
	var opt = {
		complete: false,
		serverArr: ["125.88.149.11", "183.61.119.119", "122.13.67.215", "183.232.70.183", "115.231.37.25", "221.234.42.147", "119.134.255.240", "112.90.229.26", "119.188.6.76", "125.64.99.101", "122.141.227.41", "101.71.9.107", "218.205.74.230", "125.88.149.11", "117.34.101.188", "123.139.57.108"],
		serverId: 0,
		port: 11600,
		async: true,
		base_url: "",
		xhr: null,
		idc1: {ip: "", time: 0},
		idc2: {ip: "", time: 0},
		reportUrl: "http://dr.kugou.net/v.gif?kgdt=idcsp",
		
		init: function(){
			if (!opt.complete) {
				opt.start();
			}
		},
		
		start: function() {

			if (opt.base_url) {
				return;
			}
			
			//初始化信息
			opt.serverId = Math.floor(Math.random() * opt.serverArr.length);
			opt.base_url = "http://" + opt.serverArr[opt.serverId] + ":" + opt.port + "?t=" + new Date().getTime();
			opt.xhr = opt.createCorsRequest("GET", opt.base_url, opt.async);
			opt.xhr.timeout = 1000;
			var start = new Date().getTime();
			
			if (opt.xhr) {
				opt.xhr.onload = function() {
					opt.idc1.ip = opt.serverArr[opt.serverId];
					opt.idc1.time = new Date().getTime() - start;
					opt.xhr = null;
					
					//创建第二个链接
					var serverId = opt.serverId == opt.serverArr.length - 1 ? 0 : opt.serverId + 1;
					opt.base_url = "http://" + opt.serverArr[serverId] + ":" + opt.port + "?t=" + new Date().getTime();
					opt.xhr = opt.createCorsRequest("GET", opt.base_url, opt.async);
					opt.xhr.timeout = 1000;
					
					start = new Date().getTime();
					if (opt.xhr) {
						opt.xhr.onload = function() {
							opt.idc2.ip = opt.serverArr[serverId];
							opt.idc2.time = new Date().getTime() - start;
							opt.done();
						};
						
						opt.xhr.onerror = function() {
							return;
						};
						
						opt.xhr.ontimeout = function() {
							return;
						}

						opt.xhr.send();
					}
				};
				
				opt.xhr.onerror = function() {
					return;
				};
				
				opt.xhr.ontimeout = function() {
					return;
				}

				opt.xhr.send();
				
			}
		},
		
		//初始化xmlhttprequest
		createCorsRequest: function(method, url, async) {
			
			var xhr = new XMLHttpRequest();
			if ("withCredentials" in xhr) {
				xhr.open(method, url, async);
			} else if (typeof XDomainRequest != "undefined") {
			
				//适用于IE8+
				xhr = new XDomainRequest();
				xhr.open(method, url, async);
			} else {
				
				//排除不支持跨域的IE8-
				xhr = null;
			}
			
			return xhr;
		},
		
		done: function() {
			
			opt.complete = true;
			var params = "&a=" + opt.ip2long(opt.idc1.ip) + "&t=" + opt.idc1.time;
			var img = new Image();
			img.src = opt.reportUrl + params;

			params = "&a=" + opt.ip2long(opt.idc2.ip) + "&t=" + opt.idc2.time;
			img = new Image();
			img.src = opt.reportUrl + params;
		}, 

		ip2long: function(ipStr) {
			
			var ipArr = ipStr.split(".");
			var ip = 0;
			ip = (ipArr[0] * Math.pow(256, 3)) + (ipArr[1] * Math.pow(256, 2)) + (ipArr[2] * Math.pow(256, 1)) + (ipArr[3] * Math.pow(256, 0));

			return ip;
		}
	};
	
	opt.init();
})();
