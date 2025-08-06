/**
 * Delete Confirmation Script
 * Bu script tüm silme sayfalarında kullanılabilir
 * Checkbox'lar işaretlenmediği sürece silme butonunu devre dışı bırakır
 */
document.addEventListener('DOMContentLoaded', function() {
    const confirmDeleteCheckbox = document.getElementById('confirmDelete');
    const confirmDataLossCheckbox = document.getElementById('confirmDataLoss');
    const deleteBtn = document.getElementById('deleteBtn');
    
    // Eğer gerekli elementler yoksa script çalışmasın
    if (!confirmDeleteCheckbox || !confirmDataLossCheckbox || !deleteBtn) {
        return;
    }
    
    function updateDeleteButton() {
        if (confirmDeleteCheckbox.checked && confirmDataLossCheckbox.checked) {
            deleteBtn.disabled = false;
            deleteBtn.classList.remove('disabled');
            deleteBtn.classList.add('btn-danger');
            deleteBtn.classList.remove('btn-secondary');
        } else {
            deleteBtn.disabled = true;
            deleteBtn.classList.add('disabled');
            deleteBtn.classList.remove('btn-danger');
            deleteBtn.classList.add('btn-secondary');
        }
    }
    
    // Event listeners ekle
    confirmDeleteCheckbox.addEventListener('change', updateDeleteButton);
    confirmDataLossCheckbox.addEventListener('change', updateDeleteButton);
    
    // Başlangıç durumu
    updateDeleteButton();
    
    // Form submit kontrolü
    const form = deleteBtn.closest('form');
    if (form) {
        form.addEventListener('submit', function(e) {
            if (!confirmDeleteCheckbox.checked || !confirmDataLossCheckbox.checked) {
                e.preventDefault();
                alert('Lütfen tüm onay kutularını işaretleyin.');
                return false;
            }
        });
    }
}); 