import * as toastr from 'toastr';
import { ToastrPosition, ToastrType } from '../common/enum';

export default class Toastr {
    static show(message: string, type: ToastrType, position?: ToastrPosition): void {

        switch (type) {
            case ToastrType.Success:
            default:
                toastr.success(message);
                break;
            case ToastrType.Info:
                toastr.info(message);
                break;
            case ToastrType.Warning:
                toastr.warning(message);
                break;
            case ToastrType.Error:
                toastr.error(message);
                break;
        }
    }

    private static SetToastrPosition(position: ToastrPosition) {
        switch (position) {
            case ToastrPosition.TopRight:
            default:
                return 'toast-top-right';
            case ToastrPosition.BottomLeft:
                return 'toast-bottom-left';
            case ToastrPosition.MediumLeft:
                return 'toast-medium-left';
        }
    }
}
