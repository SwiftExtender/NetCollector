class NetFighterApp {
    constructor() {
        this.api = new NetFighterAPI('http://localhost:3000'); // Adjust base URL as needed
        this.currentView = 'dashboard';
        this.init();
    }

    init() {
        this.setupEventListeners();
        this.loadDashboard();
    }

    setupNavigation() {
        document.querySelectorAll('.nav-btn').forEach(btn => {
            btn.onclick = (e) => {
                document.querySelectorAll('.nav-btn').forEach(b => b.classList.remove('active'));
                e.target.classList.add('active');

                const view = e.target.dataset.view;
                this.loadView(view);
            };
        });
    }

    async loadDomains() {
        const domains = await this.api.getDomains();
        const headers = ['ID', 'Name', 'Info'];
        const actions = [
            {
                label: 'Edit',
                type: 'secondary',
                handler: (domain) => this.editDomain(domain)
            },
            {
                label: 'Delete',
                type: 'danger',
                handler: (domain) => this.deleteDomain(domain.id)
            }
        ];

        const table = UIComponents.createTable(headers, domains, actions);

        const content = document.getElementById('content');
        content.innerHTML = `
            <div class="view-header">
                <h2>Domains</h2>
                <button class="btn btn-primary" id="addDomainBtn">Add Domain</button>
            </div>
        `;
        content.appendChild(table);

        document.getElementById('addDomainBtn').onclick = () => this.showAddDomainForm();
    }

    async loadPorts() {
        const ports = await this.api.getPorts();
        const headers = ['ID', 'Number', 'Host ID', 'Protocol', 'Info'];
        const actions = [
            {
                label: 'Edit',
                type: 'secondary',
                handler: (port) => this.editPort(port)
            },
            {
                label: 'Delete',
                type: 'danger',
                handler: (port) => this.deletePort(port.id)
            }
        ];

        const table = UIComponents.createTable(headers, ports, actions);

        const content = document.getElementById('content');
        content.innerHTML = `
            <div class="view-header">
                <h2>Ports</h2>
                <button class="btn btn-primary" id="addPortBtn">Add Port</button>
            </div>
        `;
        content.appendChild(table);

        document.getElementById('addPortBtn').onclick = () => this.showAddPortForm();
    }

    async loadTools() {
        const tools = await this.api.getTools();
        const headers = ['ID', 'Name', 'Description', 'Version'];
        const actions = [
            {
                label: 'Edit',
                type: 'secondary',
                handler: (tool) => this.editTool(tool)
            }
        ];

        const table = UIComponents.createTable(headers, tools, actions);

        const content = document.getElementById('content');
        content.innerHTML = `
            <div class="view-header">
                <h2>Tools</h2>
            </div>
        `;
        content.appendChild(table);
    }

    async loadSubnets() {
        const subnets = await this.api.getSubnets();
        const headers = ['ID', 'CIDR', 'Name', 'Description'];
        const actions = [
            {
                label: 'Edit',
                type: 'secondary',
                handler: (subnet) => this.editSubnet(subnet)
            }
        ];

        const table = UIComponents.createTable(headers, subnets, actions);

        const content = document.getElementById('content');
        content.innerHTML = `
            <div class="view-header">
                <h2>Subnets</h2>
                <button class="btn btn-primary" id="addSubnetBtn">Add Subnet</button>
            </div>
        `;
        content.appendChild(table);

        document.getElementById('addSubnetBtn').onclick = () => this.showAddSubnetForm();
    }

    // Form methods
    showAddHostForm() {
        const form = UIComponents.createForm([
            { name: 'ip', label: 'IP Address', required: true },
            { name: 'info', label: 'Info', type: 'textarea' }
        ], async (data) => {
            try {
                await this.api.createHost(data);
                UIComponents.showNotification('Host created successfully');
                this.loadHosts();
            } catch (error) {
                UIComponents.showNotification('Error creating host', 'error');
            }
        }, 'Create Host');

        UIComponents.showModal('Add Host', form);
    }

    showAddDomainForm() {
        const form = UIComponents.createForm([
            { name: 'name', label: 'Domain Name', required: true },
            { name: 'info', label: 'Info', type: 'textarea' }
        ], async (data) => {
            try {
                await this.api.createDomain(data);
                UIComponents.showNotification('Domain created successfully');
                this.loadDomains();
            } catch (error) {
                UIComponents.showNotification('Error creating domain', 'error');
            }
        }, 'Create Domain');

        UIComponents.showModal('Add Domain', form);
    }

    showAddPortForm() {
        const form = UIComponents.createForm([
            { name: 'hostId', label: 'Host ID', type: 'number', required: true },
            { name: 'number', label: 'Port Number', type: 'number', required: true },
            { name: 'protocol', label: 'Protocol', required: true },
            { name: 'info', label: 'Info', type: 'textarea' }
        ], async (data) => {
            try {
                await this.api.createPort(data);
                UIComponents.showNotification('Port created successfully');
                this.loadPorts();
            } catch (error) {
                UIComponents.showNotification('Error creating port', 'error');
            }
        }, 'Create Port');

        UIComponents.showModal('Add Port', form);
    }

    showAddSubnetForm() {
        const form = UIComponents.createForm([
            { name: 'cidr', label: 'CIDR', required: true },
            { name: 'name', label: 'Name' },
            { name: 'description', label: 'Description', type: 'textarea' }
        ], async (data) => {
            try {
                await this.api.createSubnet(data);
                UIComponents.showNotification('Subnet created successfully');
                this.loadSubnets();
            } catch (error) {
                UIComponents.showNotification('Error creating subnet', 'error');
            }
        }, 'Create Subnet');

        UIComponents.showModal('Add Subnet', form);
    }

    async showHostPorts(hostId) {
        try {
            const ports = await this.api.getHostPorts(hostId);
            const headers = ['ID', 'Number', 'Protocol', 'Info'];
            const table = UIComponents.createTable(headers, ports);
            UIComponents.showModal(`Ports for Host ${hostId}`, table);
        } catch (error) {
            UIComponents.showNotification('Error loading ports', 'error');
        }
    }
    setupEventListeners() {
        // Global error handler
        window.addEventListener('unhandledrejection', (event) => {
            console.error('Unhandled promise rejection:', event.reason);
            UIComponents.showNotification('An error occurred', 'error');
        });
    }
}

// Initialize the application when DOM is loaded
document.addEventListener('DOMContentLoaded', () => {
    new NetFighterApp();
});