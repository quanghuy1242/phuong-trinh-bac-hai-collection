package sample;

import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.stage.Stage;

public class PTController {
    @FXML
    private TextField soa, sob, soc, ketqua;
    @FXML
    private Button btnexit;

    private double a, b, c, delta, x1, x2;

    @FXML
    protected void giai() {
        try {
            a = Double.parseDouble(soa.getText().replaceAll(",", "."));
            b = Double.parseDouble(sob.getText().replaceAll(",", "."));
            c = Double.parseDouble(soc.getText().replaceAll(",", "."));

            delta = b * b - 4 * a * c;

            if (a != 0) {
                if (delta > 0) {
                    x1 = (-b + Math.sqrt(delta)) / (2 * a);
                    x2 = (-b - Math.sqrt(delta)) / (2 * a);
                    ketqua.setText("x1=" + x1 + ", x2=" + x2);
                }
                if (delta == 0) {
                    x1 = (-b) / (2 * a);
                    ketqua.setText("x=" + x1);
                }
                if (delta < 0) {
                    ketqua.setText("Phương trình vô nghiệm");
                }
            }
            if (a == 0) {
                if (b == 0) {
                    if (c == 0) ketqua.setText("Phương trình có vô số nghiệm");
                    else ketqua.setText("Phương trình vô nghiệm");
                } else {
                    x1 = (-c) / b;
                    if (x1 == 0) x1 = 0;
                    ketqua.setText("x=" + x1);
                }
            }
        } catch (Exception e) {
            ketqua.setText("Dữ liệu nhập vào phải là số và không để trống");
        }
    }

    @FXML
    protected void exit() {
        Stage stage = (Stage) btnexit.getScene().getWindow();
        stage.close();
    }

    @FXML
    protected void xoarong() {
        soa.setText("");
        sob.setText("");
        soc.setText("");
        ketqua.setText("");
    }

    @FXML
    protected void about() {
        Alert alert = new Alert(Alert.AlertType.INFORMATION);
        alert.setTitle("Thông tin chương trình");
        alert.setHeaderText("Phần mềm giải phương trình bậc hai");
        alert.setContentText("Nguyễn Quang Huy\n2018");
        alert.initOwner(btnexit.getScene().getWindow());
        alert.showAndWait();
    }
}
