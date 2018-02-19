$(function () {

	var VewModel = function () {
		var self = this; 
		self.connected = ko.observable(false); 
		self.machines = ko.observableArray();
	};

	var vm = new VewModel();
	ko.applyBindings(vm, $("#computerInfo")[0]); // Get a reference to our hub

	var conn = new signalR.HubConnection('http://localhost:1679/cpuInfo');

	conn.on('cpuInfoMessage', function (machineName, cpu, memUsage, memTotal) {
		var machine = {
			machineName: machineName,
			cpu: cpu.toFixed(0),
			memUsage: (memUsage / 1024).toFixed(2),
			memTotal: (memTotal / 1024).toFixed(2),
			memPercent: ((memUsage / memTotal) * 100).toFixed(1) + "%"
		};

		var machineModel = ko.mapping.fromJS(machine); // Check if we already have it: 

		var match = ko.utils.arrayFirst(vm.machines(), function (item) {
			return item.machineName() === machineName;
		});

		if (!match) vm.machines.push(machineModel);
		else {
			var index = vm.machines.indexOf(match);
			vm.machines.replace(vm.machines()[index], machineModel);
		}
	}); // Start the connection 


	conn.start()
		.then(() => {
			vm.connected(true);
			console.log('Started');
		})
		.catch(err => {
			console.log('Err');
		})

});