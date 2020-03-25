export class MenuConfig {
	public defaults: any = {
		header: {
			self: {},
			items: []
		},
		aside: {
			self: {},
			items: []
		},
	};

	public getConfigs(items: any[]): any {
		this.defaults.aside.items = items;
		return this.defaults;
	}
}
