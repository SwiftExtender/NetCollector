class NetFighterAPI {
    async logout() {
        const result = await this.request('/Logout', { method: 'POST' });
        this.clearAuthToken();
        return result;
    }

    // Domains API
    async getDomains(params = {}) {
        const queryString = new URLSearchParams(params).toString();
        return this.request(`/domains${queryString ? `?${queryString}` : ''}`);
    }

    async createDomain(domain, params = {}) {
        const queryString = new URLSearchParams(params).toString();
        return this.request(`/domains${queryString ? `?${queryString}` : ''}`, {
            method: 'POST',
            body: JSON.stringify(domain),
        });
    }

    async updateDomain(domain, params = {}) {
        const queryString = new URLSearchParams(params).toString();
        return this.request(`/domains${queryString ? `?${queryString}` : ''}`, {
            method: 'PATCH',
            body: JSON.stringify(domain),
        });
    }

    async deleteDomain(params = {}) {
        const queryString = new URLSearchParams(params).toString();
        return this.request(`/domains${queryString ? `?${queryString}` : ''}`, {
            method: 'DELETE',
        });
    }

    // Hosts API
    async getHosts() {
        return this.request('/hosts');
    }

    async getHostById(id) {
        return this.request(`/hosts/${id}`);
    }

    async createHost(host) {
        return this.request('/hosts', {
            method: 'POST',
            body: JSON.stringify(host),
        });
    }

    async updateHost(host) {
        return this.request('/hosts', {
            method: 'PATCH',
            body: JSON.stringify(host),
        });
    }

    async deleteHost(hostId) {
        return this.request('/hosts', {
            method: 'DELETE',
            body: JSON.stringify(hostId),
        });
    }

    // Ports API
    async getPorts() {
        return this.request('/ports');
    }

    async getPortById(id) {
        return this.request(`/ports/${id}`);
    }

    async getHostPorts(hostId) {
        return this.request(`/host/${hostId}/ports`);
    }

    async createPort(port) {
        return this.request('/ports', {
            method: 'POST',
            body: JSON.stringify(port),
        });
    }

    async updatePort(port) {
        return this.request('/ports', {
            method: 'PATCH',
            body: JSON.stringify(port),
        });
    }

    async deletePort(portId) {
        return this.request('/ports', {
            method: 'DELETE',
            body: JSON.stringify(portId),
        });
    }

    // Additional API methods for other endpoints...
    // Keywords, Params, Requests, ScanProfiles, Subnets, Tools, URLs, VHosts, etc.

    async getKeywords(params = {}) {
        const queryString = new URLSearchParams(params).toString();
        return this.request(`/keywords${queryString ? `?${queryString}` : ''}`);
    }

    async createKeyword(keyword, params = {}) {
        const queryString = new URLSearchParams(params).toString();
        return this.request(`/keywords${queryString ? `?${queryString}` : ''}`, {
            method: 'POST',
            body: JSON.stringify(keyword),
        });
    }

    async getSubnets(params = {}) {
        const queryString = new URLSearchParams(params).toString();
        return this.request(`/subnets${queryString ? `?${queryString}` : ''}`);
    }

    async createSubnet(subnet, params = {}) {
        const queryString = new URLSearchParams(params).toString();
        return this.request(`/subnets${queryString ? `?${queryString}` : ''}`, {
            method: 'POST',
            body: JSON.stringify(subnet),
        });
    }

    async getTools(params = {}) {
        const queryString = new URLSearchParams(params).toString();
        return this.request(`/tools${queryString ? `?${queryString}` : ''}`);
    }

    async createTool(tool, params = {}) {
        const queryString = new URLSearchParams(params).toString();
        return this.request(`/tools${queryString ? `?${queryString}` : ''}`, {
            method: 'POST',
            body: JSON.stringify(tool),
        });
    }

    async getUrls(params = {}) {
        const queryString = new URLSearchParams(params).toString();
        return this.request(`/urls${queryString ? `?${queryString}` : ''}`);
    }

    async createUrl(url, params = {}) {
        const queryString = new URLSearchParams(params).toString();
        return this.request(`/urls${queryString ? `?${queryString}` : ''}`, {
            method: 'POST',
            body: JSON.stringify(url),
        });
    }
}