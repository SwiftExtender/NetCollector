class UIComponents {
    static createTable(headers, data, actions = []) {
        const table = document.createElement('table');
        table.className = 'data-table';

        // Create header
        const thead = document.createElement('thead');
        const headerRow = document.createElement('tr');

        headers.forEach(header => {
            const th = document.createElement('th');
            th.textContent = header;
            headerRow.appendChild(th);
        });

        if (actions.length > 0) {
            const actionTh = document.createElement('th');
            actionTh.textContent = 'Actions';
            headerRow.appendChild(actionTh);
        }

        thead.appendChild(headerRow);
        table.appendChild(thead);

        // Create body
        const tbody = document.createElement('tbody');

        data.forEach(item => {
            const row = document.createElement('tr');

            headers.forEach(header => {
                const td = document.createElement('td');
                td.textContent = item[header.toLowerCase()] || '';
                row.appendChild(td);
            });

            if (actions.length > 0) {
                const actionTd = document.createElement('td');
                actions.forEach(action => {
                    const button = document.createElement('button');
                    button.textContent = action.label;
                    button.className = `btn btn-${action.type || 'secondary'}`;
                    button.onclick = () => action.handler(item);
                    actionTd.appendChild(button);
                });
                row.appendChild(actionTd);
            }

            tbody.appendChild(row);
        });

        table.appendChild(tbody);
        return table;
    }

    static createForm(fields, onSubmit, submitText = 'Submit') {
        const form = document.createElement('form');
        form.className = 'data-form';

        fields.forEach(field => {
            const div = document.createElement('div');
            div.className = 'form-group';

            const label = document.createElement('label');
            label.textContent = field.label;
            label.htmlFor = field.name;

            let input;
            if (field.type === 'textarea') {
                input = document.createElement('textarea');
                input.rows = 4;
            } else {
                input = document.createElement('input');
                input.type = field.type || 'text';
            }

            input.id = field.name;
            input.name = field.name;
            input.required = field.required || false;
            input.value = field.value || '';

            div.appendChild(label);
            div.appendChild(input);
            form.appendChild(div);
        });

        const submitBtn = document.createElement('button');
        submitBtn.type = 'submit';
        submitBtn.className = 'btn btn-primary';
        submitBtn.textContent = submitText;
        form.appendChild(submitBtn);

        form.onsubmit = (e) => {
            e.preventDefault();
            const formData = new FormData(form);
            const data = {};
            fields.forEach(field => {
                data[field.name] = formData.get(field.name);
            });
            onSubmit(data);
        };

        return form;
    }

    static showModal(title, content) {
        const modal = document.createElement('div');
        modal.className = 'modal-overlay';

        const modalContent = document.createElement('div');
        modalContent.className = 'modal-content';

        const modalHeader = document.createElement('div');
        modalHeader.className = 'modal-header';
        modalHeader.innerHTML = `
            <h3>${title}</h3>
            <button class="close-btn">&times;</button>
        `;

        const modalBody = document.createElement('div');
        modalBody.className = 'modal-body';
        modalBody.appendChild(content);

        modalContent.appendChild(modalHeader);
        modalContent.appendChild(modalBody);
        modal.appendChild(modalContent);

        document.body.appendChild(modal);

        // Close handlers
        modal.querySelector('.close-btn').onclick = () => modal.remove();
        modal.onclick = (e) => {
            if (e.target === modal) modal.remove();
        };

        return modal;
    }

    static showNotification(message, type = 'info') {
        const notification = document.createElement('div');
        notification.className = `notification notification-${type}`;
        notification.textContent = message;

        document.body.appendChild(notification);

        setTimeout(() => {
            notification.remove();
        }, 3000);
    }
}