DROP TABLE IF EXISTS kiosk_pending_payments;
CREATE TABLE kiosk_pending_payments (
    id INT AUTO_INCREMENT PRIMARY KEY,
    stub_no VARCHAR(20) NOT NULL,
    status ENUM('Pending', 'Completed', 'Cancelled') NOT NULL DEFAULT 'Pending',
    date_issued DATE NOT NULL,
    time_issued TIME NOT NULL,
    item_name VARCHAR(100) NOT NULL,
    quantity INT NOT NULL DEFAULT 1,
    unit_price DECIMAL(10,2) NOT NULL,
    total_amount DECIMAL(10,2) AS (quantity * unit_price) STORED
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;